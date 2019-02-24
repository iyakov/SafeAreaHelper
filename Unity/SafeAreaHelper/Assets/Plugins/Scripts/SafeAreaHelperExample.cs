using FGOL.SafeAreaHelper;
using UnityEngine;

public class SafeAreaHelperExample : MonoBehaviour
{
    private void Start()
    {
        Debug.LogError("[FGOL] ===>> START <<===");
        ISafeAreaHelper helper = SafeAreaPlugin.Create();
        var x = helper.IsInitialized;
        var z = helper.SafeArea;
        Debug.LogError("[FGOL] ===>>  END  <<===");
    }

#if UNITY_IOS
    
    [DllImport("__Internal")]
    private static extern void DemoCall1();

    [DllImport("__Internal")]
    private static extern void DemoCall2();

    IEnumerable Start()
    {
        yield return new WaitForSeconds(1f);
        DemoCall1();
        yield return new WaitForSeconds(1f);
        DemoCall2();
    }

#endif

}
