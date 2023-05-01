using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField, Range(1f, 150f)]
    private float maxHealth;

    public float CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage >= CurrentHealth)
        {
            Die();
            CurrentHealth = 0;
        }
        else
        {
            CurrentHealth -= damage;
        }
    }

    public void AddHealth(float health)
    {
        CurrentHealth += health;
    }

    private void Die()
    {
        GameManager.GetInstance().GameOver();
    }
}
