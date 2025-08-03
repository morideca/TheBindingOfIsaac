public class Triangle : Enemy, IDamageable
{
    private IMove movement;
    private Health health;

    private void Awake()
    {
        health = gameObject.AddComponent<Health>();
        health.Init(100);
        movement = new ChaoticMovement(this.gameObject, 3, 2);
        var dealDamageInTouch = gameObject.AddComponent<DealDamageInTouch>();
        dealDamageInTouch.Init(1);
    }
    
    private void Update()
    {
        movement.MoveUpdate();
    }

    public void GetDamage(float damage)
    {
        health.RemoveHealth(damage);
    }
}
