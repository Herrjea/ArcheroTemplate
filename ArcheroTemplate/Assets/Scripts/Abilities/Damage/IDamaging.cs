using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamaging
{
    void ApplyDamage(IDamageable target, Vector3 from);
}
