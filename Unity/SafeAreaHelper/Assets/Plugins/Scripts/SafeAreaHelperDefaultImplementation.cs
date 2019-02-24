namespace FGOL.SafeAreaHelper
{
    internal sealed class SafeAreaHelperDefaultImplementation : ISafeAreaHelper
    {
        private static NotchSizes DefaultSafeArea = new NotchSizes();

        public bool IsInitialized => true;

        public NotchSizes NotchSizes => DefaultSafeArea;
    }
}