using UnityEngine;


[RequireComponent(typeof(Stats))]

public class DieIfFarAway : MonoBehaviour
{
    Stats stats;


    void Awake()
    {
        stats = GetComponent<Stats>();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("RoomRims"))
            stats.Die(false);
    }
}
