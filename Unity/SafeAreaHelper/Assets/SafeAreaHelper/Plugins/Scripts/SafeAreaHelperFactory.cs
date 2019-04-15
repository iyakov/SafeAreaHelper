namespace FGOL.SafeAreaHelper
{
    /// <summary>
    /// Stateless factory method for SafeAreaHelperImplementation 
    /// for the currently selected platform.
    /// </summary>
    public static class SafeAreaHelperFactory
    {
        public static ISafeAreaHelperImplementation Create()
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
