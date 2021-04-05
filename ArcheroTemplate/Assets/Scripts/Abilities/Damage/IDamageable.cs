
using UnityEngine;


public interface IDamageable
{
    void ReceiveDamage(float amount, Vector3 from, DamageType type = DamageType.Physical);
}
