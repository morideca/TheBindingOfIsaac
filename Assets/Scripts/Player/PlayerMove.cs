using UnityEngine;

public class PlayerMove 
{
    private Rigidbody2D rb;
    private PlayerCharacteristics characteristics;
    private Vector2 currentVelocity = Vector2.zero;
    private float speed => characteristics.MoveSpeed;

    public PlayerMove(Rigidbody2D rb, PlayerCharacteristics characteristics)
    {
        this.rb = rb;
        this.characteristics = characteristics;
    }

    public void Move(Vector2 inputDirection)
    {
        float acceleration = 20f;
        Vector2 targetVelocity = inputDirection * speed;

        currentVelocity = Vector2.Lerp(rb.velocity, targetVelocity, acceleration * Time.fixedDeltaTime);

        rb.velocity = currentVelocity;
    }
}
 