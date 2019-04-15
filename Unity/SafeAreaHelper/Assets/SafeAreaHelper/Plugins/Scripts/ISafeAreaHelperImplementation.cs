namespace FGOL.SafeAreaHelper
{
    /// <summary>
    /// Allows to get intents
    /// </summary>
    public interface ISafeAreaHelperImplementation
    {
        /// <summary>
        /// Shows if the safe area is initialized by the system
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Safe area margins
        /// </summary>
        NotchSizes NotchSizes { get; }

        /// <summary>
        /// Scale factor of a device display
        /// </summary>
        float ScaleFactor { get; }
    }
}
