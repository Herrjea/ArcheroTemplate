
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
        GameEvents.PlayeGotHit.Invoke(amount);
    }

    protected void OnNewMaxHealthAbility(PlayerAbility ability)
    {
        maxHealth *= ability.multiplier;
        currentHealth *= ability.multiplier;

        print("new maxHealth: " + maxHealth);
    }
}