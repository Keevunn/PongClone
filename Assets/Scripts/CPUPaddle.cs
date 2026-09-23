using System.Collections;
using UnityEngine;

public class CPUPaddle : Paddle
{
    [SerializeField] private GameObject ball;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float targetY = Mathf.Clamp(ball.transform.position.y, minY, maxY);
        float newY = Mathf.MoveTowards(rb.position.y, targetY, speed * Time.fixedDeltaTime);
        
        rb.MovePosition(new Vector2(rb.position.x, newY));
    }

}
