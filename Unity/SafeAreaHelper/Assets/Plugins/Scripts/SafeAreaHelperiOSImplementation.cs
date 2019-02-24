#if UNITY_IOS

using System;

namespace FGOL.SafeAreaHelper
{
    internal sealed class SafeAreaHelperiOSImplementation : ISafeAreaHelper
    {
        public bool IsInitialized => throw new NotImplementedException();

        public NotchSizes SafeArea => throw new NotImplementedException();
    }
}

#endif // UNITY_IOS