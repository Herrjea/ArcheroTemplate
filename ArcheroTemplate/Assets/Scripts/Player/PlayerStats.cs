
public class PlayerStats : Stats
{
    protected override void Die()
    {
        GameEvents.PlayerDied.Invoke();
    }

    protected override void GotHit(float amount)
    {
        GameEvents.PlayeGotHit.Invoke(amount);
    }
}
