using UnityEngine;

public static class RectTansformExtens
{
    public static float GetHeightInRectangle(this Transform transform, RectTransform rectangle)
    {
        Vector2 screenCoordLine = Camera.main.WorldToScreenPoint(transform.position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectangle, screenCoordLine, Camera.main, out Vector2 localCoordLine);
        
        return rectangle.rect.height / 2 - localCoordLine.y;
    }
}
