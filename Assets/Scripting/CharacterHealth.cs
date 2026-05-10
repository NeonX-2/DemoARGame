using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterHealth : MonoBehaviour
{
    public enum CharacterType { Player, Enemy }
    
    public float maxHealth = 100f;
    public float currentHealth;

    public Slider healthBar;
    public CharacterType characterType = CharacterType.Player;

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

        // Clamp so it never goes below 0
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        // Play damage sound
        PlayDamageSound();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void PlayDamageSound()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            if (characterType == CharacterType.Enemy)
            {
                audioManager.PlayPlayerSlash();
            }
            else if (characterType == CharacterType.Player)
            {
                audioManager.PlayRedGrowl();
            }
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

        // Stop attacking
        AutoBattle battle = GetComponent<AutoBattle>();

        if (battle != null)
        {
            battle.enabled = false;
        }

        // Start delayed win screen
        StartCoroutine(ShowWinnerAfterDelay());
    }

    IEnumerator ShowWinnerAfterDelay()
    {
        // Wait for death animation
        yield return new WaitForSeconds(3f);

        AutoBattle battle = GetComponent<AutoBattle>();

        if (battle != null && battle.enemy != null)
        {
            BattleManager.Instance.DeclareWinner(battle.enemy.name);
        }

        // Destroy after animation
        Destroy(gameObject);
    }

    public bool IsDead()
    {
        return isDead;
    }
}