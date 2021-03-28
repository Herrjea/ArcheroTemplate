
public class EnemyStats : Stats
{
    protected override void Die()
    {
        GameEvents.EnemyDied.Invoke(transform.position);

        Destroy(gameObject);
    }

    protected override void GotHit(float amount)
    {
        //////////////////
    }
}
