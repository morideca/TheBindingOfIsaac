using UnityEngine;

public class SlimeProjectile : MonoBehaviour, IProjectile
{
    private float damage;
    private float forcePower = 4;
    private Rigidbody2D rb;
    
    public void Init(float damage, Vector2 dir, Vector2 playerVelocity)
    {
        this.damage = damage;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(playerVelocity * 0.4f + dir * forcePower, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Wall"))
        {
            if (other.gameObject.TryGetComponent<IDamageable>(out var health))
            {
                health.GetDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
