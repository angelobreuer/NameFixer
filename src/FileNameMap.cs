namespace NameFixer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public sealed class FileNameMap
    {
        private readonly Dictionary<FileInfo, string> _map;
        private readonly object _mapLock;

        public FileNameMap()
        {
            _mapLock = new object();
            _map = new Dictionary<FileInfo, string>();
        }

        public void Apply(bool clear = true, TextWriter output = null)
        {
            // acquire map lock
            lock (_mapLock)
            {
                // iterate through entries
                foreach (var (key, value) in _map)
                {
                    DumpEntry(key, value, output);

                    var newPath = Path.Combine(key.Directory.FullName, value);
                    if (!newPath.Equals(key.FullName))
                    {
                        File.Move(key.FullName, newPath);
                    }
                }

                if (clear)
                {
                    _map.Clear();
                }
            }
        }

        public void Clear()
        {
            lock (_mapLock)
            {
                _map.Clear();
            }
        }

        public void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            // acquire map lock
            lock (_mapLock)
            {
                // iterate through entries
                foreach (var (key, value) in _map)
                {
                    // print out mapping
                    DumpEntry(key, value, writer);
                }
            }
        }

        public void Register(FileInfo info, string name, bool preserveExtension = true)
        {
            if (!info.Exists)
            {
                throw new FileNotFoundException(info.FullName);
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The specified name can not be blank.", nameof(name));
            }

            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            if (Path.GetInvalidFileNameChars().Intersect(name).Any())
            {
                throw new ArgumentException(
                    "The specified file name contains invalid characters.", nameof(name));
            }

            // check whether the extension of the base file should be preserved
            if (preserveExtension)
            {
                // check whether the extension is already added to the file
                if (!Path.GetExtension(name).Equals(info.Extension, StringComparison.InvariantCultureIgnoreCase))
                {
                    // append extension
                    name += info.Extension;
                }
            }

            lock (_mapLock)
            {
                _map[info] = name;
            }
        }

        public void RegisterAll<T>(IEnumerable<T> enumerable, Func<T, FileInfo> fileMapper, Func<T, string> nameMapper)
            => RegisterAll(enumerable.ToDictionary(fileMapper, nameMapper));

        public void RegisterAll(IEnumerable<FileInfo> files, Func<FileInfo, string> mapper)
            => RegisterAll(files, s => s, mapper);

        public void RegisterAll(IEnumerable<KeyValuePair<FileInfo, string>> entries)
        {
            if (entries is null)
            {
                throw new ArgumentNullException(nameof(entries));
            }

            // acquire map lock
            lock (_mapLock)
            {
                // iterate through entries
                foreach (var (key, value) in entries)
                {
                    // add to dictionary
                    _map.Add(key, value);
                }
            }
        }

        private void DumpEntry(FileInfo file, string name, TextWriter output = null)
        {
            if (output is null)
            {
                return;
            }

            var path = Path.GetRelativePath(Directory.GetCurrentDirectory(), file.FullName);

            // print out mapping
            output.WriteLine($"{path} -> {name}");
        }
    }
}