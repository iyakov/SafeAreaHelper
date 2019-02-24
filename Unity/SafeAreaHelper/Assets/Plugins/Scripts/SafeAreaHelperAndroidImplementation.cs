#if UNITY_ANDROID

using System;
using UnityEngine;

namespace FGOL.SafeAreaHelper
{
    internal sealed class SafeAreaHelperAndroidImplementation : ISafeAreaHelper, IDisposable
    {
        private const string unityPlayerClass = "com.unity3d.player.UnityPlayer";
        private const string currentActivity = "currentActivity";
        private const string pluginGetInsetsName = "GetNotchSizes";

        AndroidJavaObject activity;
        public SafeAreaHelperAndroidImplementation()
        {
            if (activity == null)
            {
                Debug.Log($"[FGOL] Creating instance UnityPlayer.");
                AndroidJavaClass playerClass = new AndroidJavaClass(unityPlayerClass);
                Debug.Log($"[FGOL] Getting static Activity.");
                activity = playerClass.GetStatic<AndroidJavaObject>(currentActivity);
            }

            Debug.Log($"[FGOL] Activity: {activity}.");
        }

        public void Dispose()
        {
            activity?.Dispose();
        }

        public bool IsInitialized
        {
            get
            {
                Debug.Log($"[FGOL] Calling IsInitialized.");
                bool result = activity.Call<bool>("IsInitialized");
                Debug.Log($"[FGOL] IsInitialized: {result}.");

                return true;
            }
        }

        public NotchSizes SafeArea
        {
            get
            {
                AndroidJavaObject obj1 = activity.Call<AndroidJavaObject>(pluginGetInsetsName);

                Debug.Log($"[FGOL] GetInsets1: {obj1}.");


                NotchSizes result = new NotchSizes();
                result.Left = obj1.Get<int>(nameof(result.Left));
                result.Top = obj1.Get<int>(nameof(result.Left));
                result.Right = obj1.Get<int>(nameof(result.Right));
                result.Bottom = obj1.Get<int>(nameof(result.Bottom));

                Debug.Log($"[FGOL] GetInsets: {result}.");

                return result;
            }
        }
    }

    internal sealed class SafeAreaHelperiOSImplementation : ISafeAreaHelper
    {
        public bool IsInitialized => throw new NotImplementedException();

        public NotchSizes SafeArea => throw new NotImplementedException();
    }

    internal sealed class SafeAreaHelperDefaultImplementation : ISafeAreaHelper
    {
        private static NotchSizes DefaultSafeArea = new NotchSizes();

        public bool IsInitialized => true;

        public NotchSizes SafeArea => DefaultSafeArea;
    }
}

#endif // UNITY_ANDROID