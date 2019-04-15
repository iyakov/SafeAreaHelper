using FGOL.SafeAreaHelper;
using UnityEngine;
using UnityEngine.UI;

public class SafeAreaHelperExample : MonoBehaviour
{
#pragma warning disable 0649

    [SerializeField]
    private SafeAreaHelper safeAreaHelper;

    [SerializeField]
    private RectTransform safeAreaRectTransform;

    [SerializeField]
    private Text safeAreaText;

#pragma warning restore 0649

    private void OnEnable()
    {
        safeAreaHelper.NotchChanged += NotchChangedHandler;
    }

    private void OnDisable()
    {
        safeAreaHelper.NotchChanged -= NotchChangedHandler;
    }

    private void NotchChangedHandler(NotchSizes newNotchSizes)
    {
        UpdateSafeAreaText(newNotchSizes);
        UpdateSafeAreaVisualisation(newNotchSizes);
    }

    private void UpdateSafeAreaText(NotchSizes newNotchSizes)
    {
        safeAreaText.text = newNotchSizes.ToString();
    }

    private void UpdateSafeAreaVisualisation(NotchSizes newNotchSizes)
    {
        safeAreaRectTransform.anchoredPosition = new Vector2(
            (newNotchSizes.Left - newNotchSizes.Right) / 2f,
            (newNotchSizes.Bottom - newNotchSizes.Top) / 2
        );

        safeAreaRectTransform.sizeDelta = new Vector2(
            -(newNotchSizes.Left + newNotchSizes.Right),
            -(newNotchSizes.Bottom + newNotchSizes.Top)
        );
    }
}
