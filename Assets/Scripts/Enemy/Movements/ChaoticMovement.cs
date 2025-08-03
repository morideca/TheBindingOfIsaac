using UnityEngine;

public class ChaoticMovement : IMove
{
    private Rigidbody2D rb;
    private float timer;
    private float shiftCooldown;
    private float shiftPower = 3;
    
    public ChaoticMovement(GameObject go, float shiftPower, float shiftCooldown)
    {
        rb = go.GetComponent<Rigidbody2D>();
        this.shiftPower = shiftPower;
        this.shiftCooldown = shiftCooldown;
    }


    public void MoveUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= shiftCooldown)
        {
            Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            direction.Normalize();
            rb.AddForce(direction * shiftPower, ForceMode2D.Impulse);
            timer = 0;
        }
    }
}
