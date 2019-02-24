﻿using FGOL.SafeAreaHelper;
using UnityEngine;
using UnityEngine.UI;

public class SafeAreaHelperExample : MonoBehaviour
{
    private ISafeAreaHelper safeAreaHelper;
    private NotchSizes previousNotchSizes;

    [SerializeField]
    private RectTransform safeAreaRectTransform;

    [SerializeField]
    private Text safeAreaText;

    private void Start()
    {
        Debug.LogError("[FGOL] Using a plugin here.");
        safeAreaHelper = new SafeAreaHelperFactory().Create();
    }

    private void Update()
    {
        if (safeAreaHelper.IsInitialized)
        {
            NotchSizes newNotchSizes = safeAreaHelper.NotchSizes;

            if (newNotchSizes != previousNotchSizes)
            {
                previousNotchSizes = newNotchSizes;

                ShowNotchSizesOnScreen(newNotchSizes);
                UpdateSafeAreaRect(newNotchSizes);
            }
        }
    }

    private void ShowNotchSizesOnScreen(NotchSizes newNotchSizes)
    {
        safeAreaText.text = newNotchSizes.ToString();
    }

    private void UpdateSafeAreaRect(NotchSizes newNotchSizes)
    {
        safeAreaRectTransform.anchoredPosition = new Vector2(
            (newNotchSizes.Left - newNotchSizes.Right) / 2f,
            (newNotchSizes.Bottom - newNotchSizes.Top) / 2);

        safeAreaRectTransform.sizeDelta = new Vector2(
            -(newNotchSizes.Left + newNotchSizes.Right),
            -(newNotchSizes.Top + newNotchSizes.Bottom));
    }
}