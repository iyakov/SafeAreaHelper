package com.fgol.safearea;

import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import com.unity3d.player.UnityPlayerActivity;

public class CustomActivity extends UnityPlayerActivity
{     
    public NotchSizes notchSizes;
    public boolean isInitialized;

    protected void onCreate(Bundle savedInstanceState) 
    {
        Log.d("Unity", "[FGOL] Call onCreate");

        super.onCreate(savedInstanceState);
        notchSizes = new NotchSizes();

        //TODO: Do proper testing and/or implementation of getting a notch sizes below

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.P) 
        {
            Log.d("Unity", "[FGOL] Subscribing for OnApplyWindowInsets");

            mUnityPlayer.setOnApplyWindowInsetsListener((view, insets) -> 
            {
                Log.d("Unity", "[FGOL] Handle setOnApplyWindowInsetsListener");

                notchSizes.Left = insets.getSystemWindowInsetLeft();
                notchSizes.Top = insets.getSystemWindowInsetTop();
                notchSizes.Right = insets.getSystemWindowInsetRight();
                notchSizes.Bottom = insets.getSystemWindowInsetBottom();

                isInitialized = true;

                return insets;
            });
        }
    }

    public boolean IsInitialized()
    {
        Log.d("Unity", "[FGOL] Call IsInitialized");
        return isInitialized;
    }

    public NotchSizes GetNotchSizes()
    {
        Log.d("Unity", "[FGOL] Call GetInsets");
        return notchSizes;
    }
}