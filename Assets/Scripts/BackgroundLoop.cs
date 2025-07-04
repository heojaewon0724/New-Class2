using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < -width)
        {
            RePosition();
        }
    }
    private void RePosition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
