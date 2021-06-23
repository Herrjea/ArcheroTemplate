
public class PlayerStats : Stats
{
    protected override void Awake()
    {
        base.Awake();

        GameEvents.NewMaxHealthAbility.AddListener(OnNewMaxHealthAbility);
    }


    public override void Die(bool playAnimation = true)
    {
        GameEvents.PlayerDied.Invoke();
    }

    protected override void GotHit(float amount)
    {
        GameEvents.PlayerGotHit.Invoke(amount);
        GameEvents.NewPlayerHealthValues.Invoke(currentHealth, maxHealth);
    }

    protected override void GotHealed(float amount)
    {
        GameEvents.PlayerGotHealed.Invoke(amount);
        GameEvents.NewPlayerHealthValues.Invoke(currentHealth, maxHealth);
    }

    protected void OnNewMaxHealthAbility(PlayerAbility ability)
    {
        maxHealth *= ability.multiplier;
        currentHealth *= ability.multiplier;

        print("new maxHealth: " + maxHealth);
        GameEvents.NewPlayerHealthValues.Invoke(currentHealth, maxHealth);
    }
}