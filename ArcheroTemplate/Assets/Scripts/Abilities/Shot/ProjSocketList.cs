using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjSocketList : MonoBehaviour
{
    protected List<ProjSocket> sockets;
    protected ProjSocket newSocket;

    [SerializeField] protected float interSocketDistance = .3f;

    [SerializeField] protected Vector3 frontOffset = new Vector3(0, 0, 1);
    [SerializeField] protected Vector3 sideOffset = new Vector3(1, 0, 0);
    [SerializeField] protected Vector3 rearOffset = new Vector3(0, 0, -1);

    [SerializeField] protected GameObject muzzleFlashPrefab = null;
    protected GameObject newMuzzleFlash;


    protected virtual void Awake()
    {
        sockets = new List<ProjSocket>();

        if (muzzleFlashPrefab != null)
            newMuzzleFlash = GameObject.Instantiate(muzzleFlashPrefab, transform);
        newSocket = new ProjSocket(
            GameObject.Instantiate(new GameObject(), transform).transform,
            SocketPosition.Front,
            newMuzzleFlash?.GetComponent<ParticleSystem>()
        );
        newSocket.transform.localPosition += frontOffset;
        if (newMuzzleFlash != null)
            newMuzzleFlash.transform.localPosition = newSocket.transform.localPosition;

        sockets.Add(newSocket);
    }


    public void Shoot(ObjectPool pool, Vector3 velocity, Transform target)
    {
        GameObject projObj;
        Proj proj;

        foreach (ProjSocket socket in sockets)
        {
            projObj = pool.GetNext();
            projObj.transform.position = socket.transform.position;

            proj = projObj.GetComponent<Proj>();
            proj.Velocity = velocity;
            proj.Target = target;

            socket.NewShot();
        }
    }
}
