
public class PlayerStats : Stats
{
    protected override void Die()
    {
        GameEvents.PlayerDied.Invoke();
    }
}
