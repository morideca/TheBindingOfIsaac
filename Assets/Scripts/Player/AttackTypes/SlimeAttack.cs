using System;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class SlimeAttack : AbstractAttack
{
    private readonly GameObject projectile;
    private readonly float damage;
    
    public override TypeOfAttack Type { get; protected set; } = TypeOfAttack.slime;

    public SlimeAttack(GameObject projectile, PlayerCharacteristics characteristics) : base(characteristics) 
    {
        this.projectile = projectile;
        damage = characteristics.AttackDamage;
    }
    
    public override void Attack(Transform gun, Vector2 dir, Vector2 playerVelocity)
    {
        var bulletProjectile = Object.Instantiate(projectile, gun.position, Quaternion.identity);
        var IProjectile = bulletProjectile.GetComponent<IProjectile>();
        IProjectile.Init(damage, dir, playerVelocity);
    }
}
