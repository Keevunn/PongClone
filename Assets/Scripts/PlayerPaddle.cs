using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class PlayerPaddle : Paddle
{
    private Vector2 direction;
    private InputAction moveAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        direction = moveAction.ReadValue<Vector2>();
        direction.x = 0;
    }

    private void FixedUpdate()
    {
        if (direction.sqrMagnitude <= 0.1f) return;

        float newY = rb.position.y + direction.y * (speed * Time.fixedDeltaTime);
        newY = Mathf.Clamp(newY, minY, maxY);
        rb.MovePosition(new Vector2(rb.position.x, newY));
    }
}