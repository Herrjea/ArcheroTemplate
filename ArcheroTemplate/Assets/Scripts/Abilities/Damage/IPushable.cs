using UnityEngine;


public interface IPushable
{
    void ReceivePushForce(float strength, Vector3 from, float radius);
}
