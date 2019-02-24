package com.fgol.safeareaplugin;

import android.app.Activity;
import android.graphics.Rect;
import android.os.Build;
import android.util.Log;
import android.view.View;
import android.view.WindowInsets;

public class SafeAreaPlugin
{
    public static Activity mainActivity;
    public static final SafeAreaPlugin pluginInstance = new SafeAreaPlugin();

    public static SafeAreaPlugin GetPluginInstance()
    {
        return pluginInstance;
    }

    public Rect safeArea;
    public boolean isInitialized;

    public SafeAreaPlugin()
    {
        Log.i("Unity", "===================================Instantiated (start)");

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.P)
        {
            Log.d("Unity", "===================================Api28");

            final View parent = mainActivity.findViewById(R.id.parentPanel);

            parent.setOnApplyWindowInsetsListener(new View.OnApplyWindowInsetsListener() {
                @Override
                public WindowInsets onApplyWindowInsets(View view, WindowInsets insets) {
                    Log.d("Unity", "===================================Insets-callback");

                    safeArea = new Rect(
                            insets.getSystemWindowInsetLeft(),
                            insets.getSystemWindowInsetTop(),
                            insets.getSystemWindowInsetRight(),
                            insets.getSystemWindowInsetBottom()
                    );

                    isInitialized = true;

                    return insets;
                }
            });
        }

        Log.i("Unity", "===================================Instantiated (end)");
    }

    public boolean IsInitialized()
    {
        return isInitialized;
    }

    public Rect GetInsets()
    {
        return safeArea;
    }
}
