using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float MaskColorAlpha
    {
        get => mask.color.a;
        set => mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, value);
    }

    float velocty = 0;
    float targetMaskColor;

    const float targetMin = 0.0f;
    const float targetMax = 1.0f;

    const float smoothTime = 0.25f;

    [Space(10)]
    [SerializeField] RectTransform rectangle;

    [Space(10)]
    [SerializeField] RectTransform frame;
    [SerializeField] RectTransform line;

    [Space(10)]
    [SerializeField] RawImage mask;

    private void Start()
    {
        MaskColorAlpha = targetMaskColor = 0;
    }

    private void Update()
    {
        int CoordLineY = Mathf.RoundToInt(line.GetHeightInRectangle(frame));

        int TopY = Mathf.RoundToInt(rectangle.GetHeightInRectangle(frame) + rectangle.rect.height / 2);
        int bottomY = Mathf.RoundToInt(rectangle.GetHeightInRectangle(frame) - rectangle.rect.height / 2);

        targetMaskColor = LineInRectangle(CoordLineY, TopY, bottomY) ? targetMax : targetMin;
        LerpMask();
    }

    bool LineInRectangle(int lineY, int top, int bottom)
    {
        return lineY > bottom && lineY < top;
    }

    void LerpMask()
    {
        MaskColorAlpha = Mathf.SmoothDamp(MaskColorAlpha, targetMaskColor, ref velocty, smoothTime);
    }
}
