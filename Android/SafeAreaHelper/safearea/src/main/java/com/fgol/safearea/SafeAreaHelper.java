package com.fgol.safearea;

import android.util.Log;

public class SafeAreaHelper
{
    private static final SafeAreaHelper instance = new SafeAreaHelper();

    private static SafeAreaHelper getInstance()
    {
        return instance;
    }

    public SafeAreaHelper()
    {
        Log.i("Unity", "BBBBBBBBBBBBB");
    }

    static int x = 42;

    public int GetWidth()
    {
        Log.d("Unity","AAAAAAAAAAAAAAAAAAAAAAA");
        return x++;
    }
}
