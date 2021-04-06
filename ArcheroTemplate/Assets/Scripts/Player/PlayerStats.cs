
public class PlayerStats : Stats
{
    public override void Die(bool playAnimation = true)
    {
        GameEvents.PlayerDied.Invoke();
    }

    protected override void GotHit(float amount)
    {
        GameEvents.PlayeGotHit.Invoke(amount);
    }
}