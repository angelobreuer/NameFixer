namespace NameFixer
{
    using CommandLine;
    using CommandLine.Text;
    using NameFixer.Properties;
    using System.Linq;
    using System;
    using System.Collections.Generic;

    internal sealed class LocalizableSentenceBuilder : SentenceBuilder
    {
        /// <inheritdoc/>
        public override Func<string> ErrorsHeadingText
            => () => Resources.SentenceErrorsHeadingText;

        /// <inheritdoc/>
        public override Func<Error, string> FormatError => error =>
        {
            switch (error.Tag)
            {
                case ErrorType.BadFormatTokenError:
                    return string.Format(Resources.SentenceBadFormatTokenError, ((BadFormatTokenError)error).Token);

                case ErrorType.MissingValueOptionError:
                    return string.Format(Resources.SentenceMissingValueOptionError, ((MissingValueOptionError)error).NameInfo.NameText);

                case ErrorType.UnknownOptionError:
                    return string.Format(Resources.SentenceUnknownOptionError, ((UnknownOptionError)error).Token);

                case ErrorType.MissingRequiredOptionError when error is MissingRequiredOptionError errMissing:
                    return errMissing.NameInfo.Equals(NameInfo.EmptyName)
                        ? Resources.SentenceMissingRequiredOptionError
                        : string.Format(Resources.SentenceMissingRequiredOptionError, errMissing.NameInfo.NameText);

                case ErrorType.BadFormatConversionError when error is BadFormatConversionError badFormat:
                    return badFormat.NameInfo.Equals(NameInfo.EmptyName)
                        ? Resources.SentenceBadFormatConversionErrorValue
                        : string.Format(Resources.SentenceBadFormatConversionErrorOption, badFormat.NameInfo.NameText);

                case ErrorType.SequenceOutOfRangeError when error is SequenceOutOfRangeError seqOutRange:
                    return seqOutRange.NameInfo.Equals(NameInfo.EmptyName)
                        ? Resources.SentenceSequenceOutOfRangeErrorValue
                        : string.Format(Resources.SentenceSequenceOutOfRangeErrorOption, seqOutRange.NameInfo.NameText);

                case ErrorType.BadVerbSelectedError when error is BadVerbSelectedError badVerbSelectedError:
                    return string.Format(Resources.SentenceBadVerbSelectedError, badVerbSelectedError.Token);

                case ErrorType.NoVerbSelectedError:
                    return Resources.SentenceNoVerbSelectedError;

                case ErrorType.RepeatedOptionError:
                    return string.Format(Resources.SentenceRepeatedOptionError, ((RepeatedOptionError)error).NameInfo.NameText);

                case ErrorType.SetValueExceptionError:
                    var setValueError = (SetValueExceptionError)error;
                    return string.Format(Resources.SentenceSetValueExceptionError, setValueError.NameInfo.NameText, setValueError.Exception.Message);
            }
            throw new InvalidOperationException();
        };

        /// <inheritdoc/>
        public override Func<IEnumerable<MutuallyExclusiveSetError>, string> FormatMutuallyExclusiveSetErrors => errors =>
        {
            var bySet = errors
                .GroupBy(s => s.SetName)
                .Select(s => new { SetName = s.Key, Errors = s.ToList() });

            return string.Join(Environment.NewLine, bySet.Select(set =>
            {
                var names = string.Join(string.Empty, set.Errors
                    .Select(s => string.Format("'{0}', ", s.NameInfo.NameText)));

                var incompat = string.Join(string.Empty, bySet
                    .Where(s => !s.SetName.Equals(set.SetName))
                    .Distinct()
                    .SelectMany(s => s.Errors)
                        .Select(s => string.Format("'{0}', ", s.NameInfo.NameText)));

                return string.Format(Resources.SentenceMutuallyExclusiveSetErrors,
                    names.Substring(0, names.Length - 2), incompat.Substring(0, incompat.Length - 2));
            }));
        };

        /// <inheritdoc/>
        public override Func<bool, string> HelpCommandText => isOption => isOption
              ? Resources.SentenceHelpCommandTextOption
              : Resources.SentenceHelpCommandTextVerb;

        /// <inheritdoc/>
        public override Func<string> OptionGroupWord => () => Resources.SentenceOptionGroupWord;

        /// <inheritdoc/>
        public override Func<string> RequiredWord
            => () => Resources.SentenceRequiredWord;

        /// <inheritdoc/>
        public override Func<string> UsageHeadingText
            => () => Resources.SentenceUsageHeadingText;

        /// <inheritdoc/>
        public override Func<bool, string> VersionCommandText
            => _ => Resources.SentenceVersionCommandText;
    }
}