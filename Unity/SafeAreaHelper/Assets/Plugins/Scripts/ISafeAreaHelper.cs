namespace FGOL.SafeAreaHelper
{
    public interface ISafeAreaHelper
    {
        /// <summary>
        /// Shows if the safe area is initialized by the system
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Safe are margins
        /// </summary>
        NotchSizes SafeArea { get; }
    }
}
