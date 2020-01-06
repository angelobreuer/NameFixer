namespace NameFixer.Properties
{
    using System.Globalization;
    using System.Resources;

    /// <summary>
    ///     A class that helps with localization strings.
    /// </summary>
    public static class Resources
    {
        private static ResourceManager _resourceManager;

        /// <summary>
        ///     Gets the localized <c>"CouldNotExtractOrdinal"</c> resource string.
        /// </summary>
        public static string CouldNotExtractOrdinal => ResourceManager.GetString("CouldNotExtractOrdinal", CultureInfo);

        /// <summary>
        ///     Gets or sets a culture that overrides the current <see
        ///     cref="CultureInfo.CurrentUICulture"/> property for retrieving resources.
        /// </summary>
        public static CultureInfo CultureInfo { get; set; }

        /// <summary>
        ///     Gets the localized <c>"FolderOptionDescription"</c> resource string.
        /// </summary>
        public static string FolderOptionDescription => ResourceManager.GetString("FolderOptionDescription", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"FormatOptionDescription"</c> resource string.
        /// </summary>
        public static string FormatOptionDescription => ResourceManager.GetString("FormatOptionDescription", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"MapGenerationFailed"</c> resource string.
        /// </summary>
        public static string MapGenerationFailed => ResourceManager.GetString("MapGenerationFailed", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"PaddingOptionDescription"</c> resource string.
        /// </summary>
        public static string PaddingOptionDescription => ResourceManager.GetString("PaddingOptionDescription", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"PreserveExtensionOptionDescription"</c> resource string.
        /// </summary>
        public static string PreserveExtensionOptionDescription => ResourceManager.GetString("PreserveExtensionOptionDescription", CultureInfo);

        /// <summary>
        ///     Gets the resource manager used to fetch resources.
        /// </summary>
        public static ResourceManager ResourceManager
            => _resourceManager ?? (_resourceManager = new ResourceManager(typeof(Resources)));

        /// <summary>
        ///     Gets the localized <c>"RunningSimulation"</c> resource string.
        /// </summary>
        public static string RunningSimulation => ResourceManager.GetString("RunningSimulation", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceBadFormatConversionErrorOption"</c> resource string.
        /// </summary>
        public static string SentenceBadFormatConversionErrorOption => ResourceManager.GetString("SentenceBadFormatConversionErrorOption", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceBadFormatConversionErrorValue"</c> resource string.
        /// </summary>
        public static string SentenceBadFormatConversionErrorValue => ResourceManager.GetString("SentenceBadFormatConversionErrorValue", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceBadFormatTokenError"</c> resource string.
        /// </summary>
        public static string SentenceBadFormatTokenError => ResourceManager.GetString("SentenceBadFormatTokenError", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceBadVerbSelectedError"</c> resource string.
        /// </summary>
        public static string SentenceBadVerbSelectedError => ResourceManager.GetString("SentenceBadVerbSelectedError", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceErrorsHeadingText"</c> resource string.
        /// </summary>
        public static string SentenceErrorsHeadingText => ResourceManager.GetString("SentenceErrorsHeadingText", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceHelpCommandTextOption"</c> resource string.
        /// </summary>
        public static string SentenceHelpCommandTextOption => ResourceManager.GetString("SentenceHelpCommandTextOption", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceHelpCommandTextVerb"</c> resource string.
        /// </summary>
        public static string SentenceHelpCommandTextVerb => ResourceManager.GetString("SentenceHelpCommandTextVerb", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceMissingRequiredOptionError"</c> resource string.
        /// </summary>
        public static string SentenceMissingRequiredOptionError => ResourceManager.GetString("SentenceMissingRequiredOptionError", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceMissingRequiredValueError"</c> resource string.
        /// </summary>
        public static string SentenceMissingRequiredValueError => ResourceManager.GetString("SentenceMissingRequiredValueError", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceMissingValueOptionError"</c> resource string.
        /// </summary>
        public static string SentenceMissingValueOptionError => ResourceManager.GetString("SentenceMissingValueOptionError", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceMutuallyExclusiveSetErrors"</c> resource string.
        /// </summary>
        public static string SentenceMutuallyExclusiveSetErrors => ResourceManager.GetString("SentenceMutuallyExclusiveSetErrors", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceOptionGroupWord"</c> resource string.
        /// </summary>
        public static string SentenceOptionGroupWord => ResourceManager.GetString("SentenceOptionGroupWord", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceNoVerbSelectedError"</c> resource string.
        /// </summary>
        public static string SentenceNoVerbSelectedError => ResourceManager.GetString("SentenceNoVerbSelectedError", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceRepeatedOptionError"</c> resource string.
        /// </summary>
        public static string SentenceRepeatedOptionError => ResourceManager.GetString("SentenceRepeatedOptionError", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceRequiredWord"</c> resource string.
        /// </summary>
        public static string SentenceRequiredWord => ResourceManager.GetString("SentenceRequiredWord", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceSequenceOutOfRangeErrorOption"</c> resource string.
        /// </summary>
        public static string SentenceSequenceOutOfRangeErrorOption => ResourceManager.GetString("SentenceSequenceOutOfRangeErrorOption", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceSequenceOutOfRangeErrorValue"</c> resource string.
        /// </summary>
        public static string SentenceSequenceOutOfRangeErrorValue => ResourceManager.GetString("SentenceSequenceOutOfRangeErrorValue", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceSetValueExceptionError"</c> resource string.
        /// </summary>
        public static string SentenceSetValueExceptionError => ResourceManager.GetString("SentenceSetValueExceptionError", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceUnknownOptionError"</c> resource string.
        /// </summary>
        public static string SentenceUnknownOptionError => ResourceManager.GetString("SentenceUnknownOptionError", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceUsageHeadingText"</c> resource string.
        /// </summary>
        public static string SentenceUsageHeadingText => ResourceManager.GetString("SentenceUsageHeadingText", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SentenceVersionCommandText"</c> resource string.
        /// </summary>
        public static string SentenceVersionCommandText => ResourceManager.GetString("SentenceVersionCommandText", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SequencePrefixOptionDescription"</c> resource string.
        /// </summary>
        public static string SequencePrefixOptionDescription => ResourceManager.GetString("SequencePrefixOptionDescription", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SequenceVerbDescription"</c> resource string.
        /// </summary>
        public static string SequenceVerbDescription => ResourceManager.GetString("SequenceVerbDescription", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"SimulateOptionDescription"</c> resource string.
        /// </summary>
        public static string SimulateOptionDescription => ResourceManager.GetString("SimulateOptionDescription", CultureInfo);

        /// <summary>
        ///     Gets the localized <c>"VerboseOptionDescription"</c> resource string.
        /// </summary>
        public static string VerboseOptionDescription => ResourceManager.GetString("VerboseOptionDescription", CultureInfo);
    }
}