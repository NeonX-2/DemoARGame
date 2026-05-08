using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public Slider healthBar;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        Debug.Log(gameObject.name + " died!");

        Animator anim = GetComponent<Animator>();

        if (anim != null)
        {
            anim.SetTrigger("Die");
        }

        // Disable this object after 3 sec
        Destroy(gameObject, 3f);
    }

    public bool IsDead()
    {
        return isDead;
    }
}