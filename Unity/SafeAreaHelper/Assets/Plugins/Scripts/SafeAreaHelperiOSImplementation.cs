#if UNITY_IOS

using System.Runtime.InteropServices;

namespace FGOL.SafeAreaHelper
{
    internal sealed class SafeAreaHelperIosImplementation : ISafeAreaHelper
    {
        [DllImport("__Internal")]
        public static extern bool GetIsInitialized();

        [DllImport("__Internal")]
        public static extern float GetNotchTop();
        [DllImport("__Internal")]
        public static extern float GetNotchBottom();
        [DllImport("__Internal")]
        public static extern float GetNotchRight();
        [DllImport("__Internal")]
        public static extern float GetNotchLeft();

        [DllImport("__Internal")]
        private static extern float GetScaleFactor();

        public bool IsInitialized
        {
            get
            {
                return GetIsInitialized();
            }
        }

        public NotchSizes NotchSizes
        {
            get
            {
                NotchSizes notch = new NotchSizes
                {
                    Top = (int)GetNotchTop(),
                    Bottom = (int)GetNotchBottom(),
                    Right = (int)GetNotchRight(),
                    Left = (int)GetNotchLeft()
                };

                return notch;
            }
        }

        public float ScaleFactor
        {
            get
            {
                return GetScaleFactor();
            }
        }
    }
}

#endif // UNITY_IOS