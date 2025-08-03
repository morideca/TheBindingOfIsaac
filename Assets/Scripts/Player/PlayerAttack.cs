using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public enum TypeOfAttack 
{
    slime,
    bone,
    laser
}

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject slimeProjectile;
    [SerializeField] private GameObject gun;

    private TypeOfAttack attackType = TypeOfAttack.slime;
    private float gunOrbitRadius = 1;
    private SlimeAttack slimeAttack;
    private float attackSpeed;
    private float cooldownTimer = 1;
    private Rigidbody2D rb;
    
    [Inject]
    public void Construct(PlayerCharacteristics characteristics)
    {
        attackSpeed = characteristics.AttackSpeed;
        slimeAttack = new SlimeAttack(slimeProjectile, characteristics);
        rb = GetComponent<Rigidbody2D>();
    }

    public void Attack(TypeOfAttack typeOfAttack, Vector2 dir)
    {
        if (cooldownTimer >= 1 / attackSpeed)
        {
            switch (typeOfAttack)
            {
                case TypeOfAttack.slime:
                    if (slimeAttack == null)
                    {
                        Debug.Log("slime attack = null");
                        return;
                    }
                    slimeAttack.Attack(gun.transform, dir, rb.velocity);
                    Debug.Log(rb.velocity);
                    break;
                case TypeOfAttack.bone:
                    break;
                case TypeOfAttack.laser:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeOfAttack), typeOfAttack, null);
            }

            cooldownTimer = 0;
        }
    }

    public void OnFire(Vector2 dir)
    {
        gun.transform.position = (Vector2)transform.position + dir.normalized * gunOrbitRadius;
        Attack(attackType, dir);
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
}
