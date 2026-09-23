using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float baseSpeed = 100;
    [SerializeField] private float maxSpeed = 500;
    private float currentSpeed;

    private Vector2 initPos;

    private GameManager GameManager;

    private bool isActive;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initPos = rb.position;

        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        AddStartingForce();
    }
    private void FixedUpdate()
    {
        if (!isActive) return;
        
        if (rb.linearVelocity.sqrMagnitude < 0.01f) // if zero velocity add random force
        {
            AddStartingForce();
            return;
        }

        Vector2 dir = rb.linearVelocity.normalized;
        
        if (Mathf.Abs(dir.x) < 0.25f)
        {
            dir.x = Mathf.Sign(dir.x == 0 ? Random.Range(-1f, 1f) : dir.x) * 0.25f; // min horizontal speed = 0.25f
            dir = dir.normalized;
        }
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        rb.linearVelocity = dir * currentSpeed;
     }

    public void ResetSelf()
    {
        rb.position = initPos;
        rb.linearVelocity = Vector2.zero;
        isActive = false;
    }

    public void AddStartingForce()
    {
        isActive = true;
        float x = Random.value < 0.5f ? -1f : 1f; // left: -1f ; right: 1f
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f); // 50/50 for up or down movement

        Vector2 dir = new Vector2(x, y).normalized;
        rb.AddForce(dir * baseSpeed, ForceMode2D.Impulse);
        currentSpeed = baseSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            Collider2D paddle = other.collider;

            Vector2 ballDir = rb.linearVelocity.normalized;
            Vector2 contactDist = rb.transform.position - paddle.bounds.center;
            Vector2 surfaceNormal = other.GetContact(0).normal;
            Vector3 rotAxis = Vector3.Cross(Vector3.up, surfaceNormal);

            float maxBounceAngle = 75f;
            float bounceAngle = contactDist.y / paddle.bounds.size.y * maxBounceAngle;
            ballDir = Quaternion.AngleAxis(bounceAngle, rotAxis) * ballDir;

            rb.linearVelocity = ballDir * rb.linearVelocity.magnitude;
        }

        if (other.gameObject.CompareTag("LWall"))
        {
            GameManager.UpdateCPUScore(1);
        }
        
        if (other.gameObject.CompareTag("RWall"))
        {
            GameManager.UpdatePlayerScore(1);
        }
    }
    
}
