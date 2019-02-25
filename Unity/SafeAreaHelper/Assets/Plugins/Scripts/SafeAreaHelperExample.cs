using FGOL.SafeAreaHelper;
using UnityEngine;
using UnityEngine.UI;

public class SafeAreaHelperExample : MonoBehaviour
{
    private ISafeAreaHelper safeAreaHelper;
    private NotchSizes previousNotchSizes;

#pragma warning disable 0649

    [SerializeField]
    private RectTransform safeAreaRectTransform;

    [SerializeField]
    private Text safeAreaText;

#pragma warning restore 0649

    private void Start()
    {
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
            -(newNotchSizes.Bottom + newNotchSizes.Top));

        //TODO: convert device's points into Unity's units
        // var deviceOffsetTop = newNotchSizes.Top * safeAreaHelper.ScaleFactor / Camera.main.pixelHeight;
        // var rootCanvas = GetComponent<RectTransform>().GetComponentInParent<Canvas>().rootCanvas;
        // var canvasSize = rootCanvas.gameObject.GetComponent<RectTransform>().rect.size;
        // var unityOffsetTop = canvasSize.y * deviceOffsetTop;
    }
}
