using UnityEngine;

public class AutoBattle : MonoBehaviour
{
    public CharacterHealth enemy;

    [Header("Damage Range")]
    public float minDamage = 5f;
    public float maxDamage = 20f;

    [Header("Attack Speed")]
    public float minAttackTime = 1f;
    public float maxAttackTime = 3f;

    [Header("Critical Hit")]
    public float criticalChance = 20f;
    public float criticalMultiplier = 2f;

    [Header("Dodge Chance")]
    public float dodgeChance = 10f;

    private float attackTimer;
    private float nextAttackTime;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        SetNextAttackTime();
    }

    void Update()
    {
        if (enemy == null) return;

        if (enemy.IsDead()) return;

        if (!gameObject.activeInHierarchy) return;

        if (!enemy.gameObject.activeInHierarchy) return;

        attackTimer += Time.deltaTime;

        if (attackTimer >= nextAttackTime)
        {
            Attack();

            attackTimer = 0f;

            SetNextAttackTime();
        }
    }

    void SetNextAttackTime()
    {
        nextAttackTime = Random.Range(minAttackTime, maxAttackTime);
    }

    void Attack()
    {
        if (anim != null)
        {
            anim.SetTrigger("Attack");
        }

        // Dodge check
        float dodgeRoll = Random.Range(0f, 100f);

        if (dodgeRoll <= dodgeChance)
        {
            Debug.Log(enemy.name + " dodged!");
            return;
        }

        // Random damage
        float damage = Random.Range(minDamage, maxDamage);

        // Critical hit check
        float critRoll = Random.Range(0f, 100f);

        bool isCritical = critRoll <= criticalChance;

        if (isCritical)
        {
            damage *= criticalMultiplier;

            Debug.Log(gameObject.name + " CRITICAL HIT!");
        }

        Debug.Log(gameObject.name + " dealt " + damage + " damage.");

        enemy.TakeDamage(damage);
    }
}