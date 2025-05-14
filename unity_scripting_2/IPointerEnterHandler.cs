public class AccessibilitySettings : MonoBehaviour
{
    public TMPro.TMP_Text[] allText;
    public float largeTextSize = 24f;

    public void EnableLargeText(bool enabled)
    {
        foreach (var txt in allText)
            txt.fontSize = enabled ? largeTextSize : 16f;
    }
}
