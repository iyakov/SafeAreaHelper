#if UNITY_IOS

using System.Runtime.InteropServices;

namespace FGOL.SafeAreaHelper
{
    internal sealed class SafeAreaHelperIosImplementation : ISafeAreaHelper
    {
        [DllImport("__Internal")]
        public static extern bool GetIsInitialized();

        [DllImport("__Internal")]
        public static extern MarshalRect GetNotch();

        [DllImport("__Internal")]
        private static extern float GetScaleFactor();

        [StructLayout(LayoutKind.Sequential)]
        public struct MarshalRect { public float top, right, bottom, left; }

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
                MarshalRect result = GetNotch();
                NotchSizes notch = new NotchSizes
                {
                    Top = (int)result.top,
                    Right = (int)result.right,
                    Bottom = (int)result.bottom,
                    Left = (int)result.left,
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