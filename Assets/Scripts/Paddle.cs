using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected Rigidbody2D rb;

    [SerializeField] protected float speed = 10f;

    protected float maxY = 2.75f;
    protected float minY = -3.75f;
    
    private Vector2 initPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initPos = rb.position;
    }

    public void ResetSelf()
    {
        rb.linearVelocity = Vector2.zero;
        rb.position = initPos;
    }
}
