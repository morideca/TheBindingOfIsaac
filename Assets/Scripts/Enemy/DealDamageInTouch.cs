using System;
using UnityEngine;

public class DealDamageInTouch : MonoBehaviour
{
    private int damage;
    
    public void Init(int damage)
    {
        this.damage = damage;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<IDamageable>();
            player.GetDamage(damage);
        }
    }
}
