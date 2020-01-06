namespace NameFixer.Properties
{
    using System.Globalization;
    using System.Resources;

    /// <summary>
    ///     A class that helps with localization strings.
    /// </summary>
    internal static class Resources
    {
        private static ResourceManager _resourceManager;

        /// <summary>
        ///     Gets or sets a culture that overrides the current <see
        ///     cref="CultureInfo.CurrentUICulture"/> property for retrieving resources.
        /// </summary>
        public static CultureInfo CultureInfo { get; set; }

        /// <summary>
        ///     Gets the resource manager used to fetch resources.
        /// </summary>
        public static ResourceManager ResourceManager
            => _resourceManager ?? (_resourceManager = new ResourceManager(typeof(Resources)));

        /// <summary>
        ///     Gets the localized <c>"CouldNotExtractOrdinal"</c> resource string.
        /// </summary>
        public static string CouldNotExtractOrdinal => ResourceManager.GetString("CouldNotExtractOrdinal", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"MapGenerationFailed"</c> resource string.
        /// </summary>
        public static string MapGenerationFailed => ResourceManager.GetString("MapGenerationFailed", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"RunningSimulation"</c> resource string.
        /// </summary>
        public static string RunningSimulation => ResourceManager.GetString("RunningSimulation", CultureInfo);
    }
}