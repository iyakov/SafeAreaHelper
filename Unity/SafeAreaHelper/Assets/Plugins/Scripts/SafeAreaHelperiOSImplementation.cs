#if UNITY_IOS

using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace FGOL.SafeAreaHelper
{
    internal sealed class SafeAreaHelperiOSImplementation : ISafeAreaHelper
    {
        [DllImport("__Internal")]
        public static extern void DemoCall1();

        [DllImport("__Internal")]
        public static extern void DemoCall2();

        public bool IsInitialized
        {
            get
            {
                try
                {
                    DemoCall1();
                }
                catch (Exception e)
                {
                    Debug.Log("[FGOL] ERROR: " + e);
                }
                try
                {
                    DemoCall2();
                }
                catch (Exception e)
                {
                    Debug.Log("[FGOL] ERROR: " + e);
                }


                return false;
            }
        }

        public NotchSizes NotchSizes => throw new NotImplementedException();
    }
}

#endif // UNITY_IOS