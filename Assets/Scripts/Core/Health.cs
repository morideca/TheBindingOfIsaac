using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HealthPoints { get; private set; } = 20;
    public float maxHealthPoints { get; private set; } = 20;
    public event Action<float> OnHealthChanged;

    public void Init(float health)
    {
        maxHealthPoints = health;
        HealthPoints = health;
    }

    public void AddHealth(float amount)
    {
        HealthPoints += amount;
        OnHealthChanged?.Invoke(HealthPoints);
    }

    public void RemoveHealth(float amount)
    {
        HealthPoints -= amount;
        OnHealthChanged?.Invoke(HealthPoints);
        if (HealthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
