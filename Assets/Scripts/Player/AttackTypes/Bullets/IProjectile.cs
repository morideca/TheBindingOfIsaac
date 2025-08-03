using UnityEngine;

public interface IProjectile
{
    public void Init(float damage, Vector2 dir, Vector2 playerVelocity);
}
