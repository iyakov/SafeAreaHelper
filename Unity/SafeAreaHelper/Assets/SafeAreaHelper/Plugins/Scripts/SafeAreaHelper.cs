using System;
using FGOL.SafeAreaHelper;
using UnityEngine;

public class SafeAreaHelper : MonoBehaviour
{
    private ISafeAreaHelperImplementation implementation;
    private NotchSizes previousNotchSizes;
    private Camera mainCamera;
    private Canvas rootCanvas;
    private RectTransform rootCanvasRect;

    public event Action<NotchSizes> NotchChanged;

    private void Awake()
    {
        implementation = SafeAreaHelperFactory.Create();

        //mainCamera = Camera.main;
        //rootCanvas = GetComponentInParent<Canvas>().rootCanvas;
        //rootCanvasRect = rootCanvas.gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (implementation.IsInitialized)
        {
            NotchSizes newNotchSizes = implementation.NotchSizes;

            if (newNotchSizes != previousNotchSizes)
            {
                previousNotchSizes = ConvertDevicePointsToUnityUnits(newNotchSizes);
                NotchChanged?.Invoke(previousNotchSizes);
            }
        }
    }

    private NotchSizes ConvertDevicePointsToUnityUnits(NotchSizes deviceSizes)
    {
        //NotchSizes unitySizes; 
        //float deviceOffsetTop = deviceSizes.Top * implementation.ScaleFactor / mainCamera.pixelHeight;
        //var canvasSize = rootCanvas.rect.size;
        //var unityOffsetTop = canvasSize.y * deviceOffsetTop;
        //unitySizes.Top = (int)unityOffsetTop;

        return deviceSizes;
    }
}
