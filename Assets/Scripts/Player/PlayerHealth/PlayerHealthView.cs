using TMPro;
using UnityEngine;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] public TMP_Text healthText;

    public void OnHealthChanged(int currentHealth, int maxHealth)
    {
        // healthText.text = $"{currentHealth.ToString()} / {maxHealth.ToString()}";
    }
}
