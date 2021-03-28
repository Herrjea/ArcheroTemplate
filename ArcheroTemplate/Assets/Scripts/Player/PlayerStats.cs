
public class PlayerStats : Stats
{
    protected override void Die()
    {
        GameEvents.PlayerDied.Invoke();

        Destroy(gameObject);
    }

    protected override void GotHit(float amount)
    {
        GameEvents.PlayeGotHit.Invoke(amount);
    }
}
