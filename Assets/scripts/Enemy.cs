using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;

    private Rigidbody2D rb;
    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void Update()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;

        rb.linearVelocity = new Vector2((movingRight ? 1 : -1) * speed, 0); //← KHÔNG RƠI NỮA

        if (transform.position.x >= rightBound)
        {
            movingRight = false;
            Flip();
        }
        else if (transform.position.x <= leftBound)
        {
            movingRight = true;
            Flip();
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
}
