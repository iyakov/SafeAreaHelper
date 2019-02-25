namespace FGOL.SafeAreaHelper
{
    /// <summary>
    /// Allows to get 
    /// </summary>
    public interface ISafeAreaHelper
    {
        /// <summary>
        /// Shows if the safe area is initialized by the system
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Safe are margins
        /// </summary>
        NotchSizes NotchSizes { get; }

        /// <summary>
        /// Scale factor
        /// </summary>
        float ScaleFactor { get; }
    }
}
