using UnityEngine;

public class Stats : MonoBehaviour, IDamageable
{
    [SerializeField] protected float maxHealth = 10;
    [SerializeField] protected float defense = 1;

    [SerializeField] float currentHealth;

    protected DeathAnimation deathAnimation;
    protected HitBlood hitBlood;


    protected virtual void Awake()
    {
        currentHealth = maxHealth;

        deathAnimation = GetComponent<DeathAnimation>();
        hitBlood = GetComponent<HitBlood>();
    }


    public void ReceiveDamage(float amount, Vector3 from, DamageType type = DamageType.Physical)
    {
        currentHealth -= amount;

        Bleed(from);

        if (currentHealth <= 0)
            Die();
        else
            GotHit(amount);
    }


    public virtual void Die(bool playAnimation = true)
    {
        Debug.Log("Unimplemented Stats::Die member on object " + gameObject.name + ".");
    }

    protected virtual void GotHit(float amount)
    {
        Debug.Log("Unimplemented Stats::GotHit member on object " + gameObject.name + ".");
    }

    protected virtual void Bleed(Vector3 contactPoint)
    {
        //Debug.LogError("Unimplemented Stats::Bleed member on object " + gameObject.name + ".");
        hitBlood?.Play(contactPoint - transform.position);
    }
}
