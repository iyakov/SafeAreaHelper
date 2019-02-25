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
                AndroidJavaClass playerClass = new AndroidJavaClass(UnityPlayerClassName);
                activity = playerClass.GetStatic<AndroidJavaObject>(CurrentActivityFieldName);
            }
        }

        public void Dispose()
        {
            activity?.Dispose();
        }

        public bool IsInitialized
        {
            get
            {
                bool result = activity.Call<bool>(IsInitializedMethodName);
                return result;
            }
        }

        public NotchSizes NotchSizes
        {
            get
            {
                AndroidJavaObject notchResult = activity.Call<AndroidJavaObject>(GetNotchMethodName);
                
                NotchSizes result = new NotchSizes();
                result.Left = notchResult.Get<int>(nameof(result.Left));
                result.Top = notchResult.Get<int>(nameof(result.Left));
                result.Right = notchResult.Get<int>(nameof(result.Right));
                result.Bottom = notchResult.Get<int>(nameof(result.Bottom));

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