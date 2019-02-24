namespace FGOL.SafeAreaHelper
{
    public static class SafeAreaPlugin
    {
        public static ISafeAreaHelper Create()
        {
#if UNITY_IOS
            return new SafeAreaHelperIosImplementation();
#elif UNITY_ANDROID
            return new SafeAreaHelperAndroidImplementation();
#else
            return new SafeAreaHelperDefaultImplementation();
#endif
        }
    }
}
