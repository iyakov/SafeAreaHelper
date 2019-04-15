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

        mainCamera = Camera.main;
        rootCanvas = GetComponentInParent<Canvas>().rootCanvas;
        rootCanvasRect = rootCanvas.gameObject.GetComponent<RectTransform>();
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

    private NotchSizes ConvertDevicePointsToUnityUnits(NotchSizes sizeInPoints)
    {
        NotchSizes sizeInUnits = sizeInPoints; 

        Vector2 canvasSize = rootCanvasRect.rect.size;
        float pointToUnitVerticalCoefficient = canvasSize.y * implementation.ScaleFactor / mainCamera.pixelHeight;
        float pointToUnitHorizontalCoefficient = canvasSize.x * implementation.ScaleFactor / mainCamera.pixelWidth;

        //TODO: Precision loss

        sizeInUnits.Top = (int)(sizeInPoints.Top * pointToUnitVerticalCoefficient);
        sizeInUnits.Bottom = (int)(sizeInPoints.Bottom * pointToUnitVerticalCoefficient);

        sizeInUnits.Right = (int)(sizeInPoints.Right * pointToUnitHorizontalCoefficient);
        sizeInUnits.Left = (int)(sizeInPoints.Left * pointToUnitHorizontalCoefficient);

        return sizeInUnits;
    }
}
