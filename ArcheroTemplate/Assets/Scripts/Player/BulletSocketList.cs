using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSocketList : MonoBehaviour
{
    List<BulletSocket> sockets;
    BulletSocket newSocket;

    [SerializeField] float interSocketDistance = .3f;

    [SerializeField] Vector3 frontOffset = new Vector3(0, 0, 1);
    [SerializeField] Vector3 sideOffset = new Vector3(1, 0, 0);
    [SerializeField] Vector3 rearOffset = new Vector3(0, 0, -1);


    private void Awake()
    {
        sockets = new List<BulletSocket>();

        newSocket = new BulletSocket(
            GameObject.Instantiate(new GameObject(), transform).transform,
            SocketPosition.Front
        );
        newSocket.transform.position += frontOffset;

        sockets.Add(newSocket);

        GameEvents.PlayerShot.AddListener(Shoot);
    }


    public void Shoot(GameObject prefab, Vector3 velocity)
    {
        GameObject projectile;

        foreach (BulletSocket socket in sockets)
        {
            projectile = GameObject.Instantiate(
                prefab,
                socket.transform.position,
                Quaternion.identity
            );
            projectile.GetComponent<Projectile>().velocity = velocity;
        }
    }
}
