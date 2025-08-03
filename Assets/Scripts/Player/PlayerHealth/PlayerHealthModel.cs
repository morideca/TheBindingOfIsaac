using System;

public class PlayerHealthModel
{
    private int maxHealth;
    private int currentHealth;
    
    public event Action<int, int> OnHealthChanged;
    public event Action OnHealthEqualsZero;

    public PlayerHealthModel(int maxHealth, int currentHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
    }

    public void Init()
    {
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void AddHealth(int damage)
    {
        currentHealth += damage;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void RemoveHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
            OnHealthEqualsZero?.Invoke();
        }
        else
        {
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }
}
