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
        float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        transform.position = new Vector2(transform.position.x, y);
    }
}
