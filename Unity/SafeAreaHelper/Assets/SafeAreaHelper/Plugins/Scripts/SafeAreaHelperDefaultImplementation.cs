namespace FGOL.SafeAreaHelper
{
    internal sealed class SafeAreaHelperDefaultImplementation : ISafeAreaHelperImplementation
    {
        private static NotchSizes DefaultSafeArea = new NotchSizes();

        public bool IsInitialized => true;

        public NotchSizes NotchSizes => DefaultSafeArea;

        public float ScaleFactor => 1.0f;
    }
}