using UnityEngine;

public class Line : MonoBehaviour, IMovable
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move();
        }
    }

    public void Move()
    {
        Vector2 mouseLocal = transform.parent.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        transform.localPosition = new Vector2(transform.localPosition.x, mouseLocal.y);
    }
}
