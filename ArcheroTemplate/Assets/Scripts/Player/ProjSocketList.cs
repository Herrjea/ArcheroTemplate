using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjSocketList : MonoBehaviour
{
    List<ProjSocket> sockets;
    ProjSocket newSocket;

    [SerializeField] float interSocketDistance = .3f;

    [SerializeField] Vector3 frontOffset = new Vector3(0, 0, 1);
    [SerializeField] Vector3 sideOffset = new Vector3(1, 0, 0);
    [SerializeField] Vector3 rearOffset = new Vector3(0, 0, -1);


    private void Awake()
    {
        sockets = new List<ProjSocket>();

        newSocket = new ProjSocket(
            GameObject.Instantiate(new GameObject(), transform).transform,
            SocketPosition.Front
        );
        newSocket.transform.position += frontOffset;

        sockets.Add(newSocket);

        GameEvents.PlayerShot.AddListener(Shoot);
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
            proj.velocity = velocity;
            proj.target = target;
        }
    }
}
