#if UNITY_ANDROID

using System;
using UnityEngine;

namespace FGOL.SafeAreaHelper
{
    internal sealed class SafeAreaHelperAndroidImplementation : ISafeAreaHelper, IDisposable
    {
        private const string UnityPlayerClassName = "com.unity3d.player.UnityPlayer";
        private const string CurrentActivityFieldName = "currentActivity";
        private const string GetNotchMethodName = "GetNotchSizes";
        private const string IsInitializedMethodName = "IsInitialized";

        private AndroidJavaObject activity;

        public SafeAreaHelperAndroidImplementation()
        {
            if (activity == null)
            {
                Debug.Log($"[FGOL] Creating instance UnityPlayer.");
                AndroidJavaClass playerClass = new AndroidJavaClass(UnityPlayerClassName);
                Debug.Log($"[FGOL] Getting static Activity.");
                activity = playerClass.GetStatic<AndroidJavaObject>(CurrentActivityFieldName);
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
                Debug.Log($"[FGOL] Calling {IsInitializedMethodName}.");
                bool result = activity.Call<bool>(IsInitializedMethodName);
                Debug.Log($"[FGOL] {IsInitializedMethodName}: {result}.");

                return true;
            }
        }

        public NotchSizes NotchSizes
        {
            get
            {
                Debug.Log($"[FGOL] Calling {GetNotchMethodName}.");
                AndroidJavaObject notchResult = activity.Call<AndroidJavaObject>(GetNotchMethodName);
                Debug.Log($"[FGOL] {GetNotchMethodName}: {notchResult}.");
                
                NotchSizes result = new NotchSizes();
                result.Left = notchResult.Get<int>(nameof(result.Left));
                result.Top = notchResult.Get<int>(nameof(result.Left));
                result.Right = notchResult.Get<int>(nameof(result.Right));
                result.Bottom = notchResult.Get<int>(nameof(result.Bottom));

                Debug.Log($"[FGOL] {GetNotchMethodName}: {result}.");

                return result;
            }
        }

        public float ScaleFactor
        {
            get
            {
                return Screen.dpi / 160.0f;
            }
        }
    }
}

#endif // UNITY_ANDROID