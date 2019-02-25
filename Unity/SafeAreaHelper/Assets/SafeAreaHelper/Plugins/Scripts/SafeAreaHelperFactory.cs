namespace FGOL.SafeAreaHelper
{
    public sealed class SafeAreaHelperFactory
    {
        public ISafeAreaHelper Create()
        {
#if UNITY_EDITOR
            return new SafeAreaHelperDefaultImplementation();
#elif UNITY_IOS
            return new SafeAreaHelperIosImplementation();
#elif UNITY_ANDROID
            return new SafeAreaHelperAndroidImplementation();
#else
            return new SafeAreaHelperDefaultImplementation();
#endif
        }
    }
}
