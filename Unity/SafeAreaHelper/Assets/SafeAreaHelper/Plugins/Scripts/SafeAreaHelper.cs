using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaHelper : MonoBehaviour
{

#if UNITY_ANDROID

    private const string pluginName = "com.fgol.safeareaplugin.SafeAreaPlugin";
    private const string pluginCtorName = "GetPluginInstance";
    private const string pluginIsInitializedName = "IsInitialized";
    private const string pluginGetInsetsName = "GetInsets";

    private AndroidJavaClass pluginClass;
    private AndroidJavaObject pluginInstance;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        IsInitialized();
        yield return new WaitForSeconds(1);
        IsInitialized();
        yield return new WaitForSeconds(1);
        IsInitialized();
        yield return new WaitForSeconds(1);
        GetInsets();
    }

    private void OnDestroy()
    {
        pluginInstance?.Dispose();
        pluginClass?.Dispose();
    }

    public AndroidJavaObject GetPlugin()
    {
        if (pluginInstance == null)
        {
            Debug.Log($"[FGOL] Creating instance of {pluginName}.");

            pluginClass = new AndroidJavaClass(pluginName);

            AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            pluginClass.SetStatic("mainActivity", activity);

            pluginInstance = pluginClass.CallStatic<AndroidJavaObject>(pluginCtorName);
        }

        Debug.Log($"[FGOL] GetPlugin: {pluginInstance}.");
        return pluginInstance;
    }

    public bool IsInitialized()
    {
        bool result = GetPlugin().Call<bool>(pluginIsInitializedName);

        Debug.Log($"[FGOL] IsInitialized: {result}.");

        return result;
    }

    public PluginRect GetInsets()
    {
        AndroidJavaObject obj = GetPlugin().Call<AndroidJavaObject>(pluginGetInsetsName);

        PluginRect result = new PluginRect();
        result.left = obj.Get<int>(nameof(result.left));
        result.top = obj.Get<int>(nameof(result.left));
        result.right = obj.Get<int>(nameof(result.right));
        result.bottom = obj.Get<int>(nameof(result.bottom));

        Debug.Log($"[FGOL] GetInsets: {result}.");

        return result;
    }

    public class PluginRect
    {
        public int left, top, right, bottom;

        public override string ToString()
        {
            return $"({left},{top},{right},{bottom})";
        }
    }

#elif UNITY_IOS

    IEnumerable Start()
    {
    }

#endif

}
