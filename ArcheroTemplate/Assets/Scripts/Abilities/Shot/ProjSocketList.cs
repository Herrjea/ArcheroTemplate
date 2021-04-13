using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjSocketList : MonoBehaviour
{
    protected List<ProjSocket> sockets;
    protected ProjSocket newSocket;

    [SerializeField] protected float interSocketDistance = .4f;

    [SerializeField] protected Vector3 frontOffset = new Vector3(0, 0, 1);
    [SerializeField] protected Vector3 sideOffset = new Vector3(1, 0, 0);
    [SerializeField] protected Vector3 rearOffset = new Vector3(0, 0, -1);

    protected Vector3 frontDisplacement = new Vector3(1, 0, 0);
    protected Vector3 sideDisplacement = new Vector3(0, 0, 1);
    protected Vector3 rearDisplacement = new Vector3(1, 0, 0);

    [SerializeField] protected GameObject muzzleFlashPrefab = null;
    protected GameObject newMuzzleFlash;


    protected virtual void Awake()
    {
        sockets = new List<ProjSocket>();

        MoreProjs(SocketPosition.Front);
    }


    public void Shoot(ObjectPool pool, Vector3 velocity, Transform target, bool shouldCopySocketRotation = false)
    {
        GameObject projObj;
        Proj proj;

        foreach (ProjSocket socket in sockets)
        {
            projObj = pool.GetNext();
            projObj.transform.position = socket.transform.position;
            if (shouldCopySocketRotation)
                projObj.transform.rotation = socket.transform.rotation;

            proj = projObj.GetComponent<Proj>();
            proj.Velocity = velocity;
            proj.Target = target;

            socket.NewShot();
        }
    }

    protected void MoreProjs(SocketPosition position)
    {
        List<ProjSocket> found = new List<ProjSocket>();

        // Get all current sockets in the desired position
        foreach (ProjSocket socket in sockets)
            if (socket.position == position)
                found.Add(socket);

        // Instantiate a new one
        newSocket = AddSocketToList(position);

        // If there was none of its kind,
        // finished we have
        if (found.Count == 0)
            return;

        // Otherwise, move all the needed ones
        // to make space for the new one
        found.Add(newSocket);
        Vector3 offset = PositionToOffset(position);
        Vector3 displacement = PositionToDisplacement(position);
        for (int i = 0; i < found.Count; i++)
            found[i].transform.localPosition =
                offset
                +
                displacement * (i - (found.Count / 2.0f)) * interSocketDistance;
    }


    protected ProjSocket AddSocketToList(SocketPosition position)
    {
        if (muzzleFlashPrefab != null)
            newMuzzleFlash = GameObject.Instantiate(muzzleFlashPrefab, transform);
        newSocket = new ProjSocket(
            GameObject.Instantiate(new GameObject(), transform).transform,
            position,
            newMuzzleFlash?.GetComponent<ParticleSystem>()
        );
        newSocket.transform.localPosition += PositionToOffset(position);
        newSocket.transform.rotation = PositionToRotation(position);
        if (newMuzzleFlash != null)
        {
            newMuzzleFlash.transform.localPosition = newSocket.transform.localPosition;
            newMuzzleFlash.transform.rotation = newSocket.transform.rotation;
        }

        sockets.Add(newSocket);

        // Leave it blank for the next time the func is called
        newMuzzleFlash = null;

        return newSocket;
    }


    #region SocketPosition transformations

    protected Vector3 PositionToOffset(SocketPosition position)
    {
        switch (position)
        {
            case SocketPosition.Front: return frontOffset;
            case SocketPosition.Left: return -sideOffset;
            case SocketPosition.Right: return sideOffset;
            case SocketPosition.Rear: return rearOffset;

            default:
                print("Unknown SocketPosition value: " + position);
                return Vector3.zero;
        }
    }

    protected Vector3 PositionToDisplacement(SocketPosition position)
    {
        switch (position)
        {
            case SocketPosition.Front: return frontDisplacement;
            case SocketPosition.Left: return sideDisplacement;
            case SocketPosition.Right: return sideDisplacement;
            case SocketPosition.Rear: return rearDisplacement;

            default:
                print("Unknown SocketPosition value: " + position);
                return Vector3.zero;
        }
    }

    protected Quaternion PositionToRotation(SocketPosition position)
    {
        switch (position)
        {
            case SocketPosition.Front: return Quaternion.identity;
            case SocketPosition.Left: return Quaternion.AngleAxis(-90, Vector3.up);
            case SocketPosition.Right: return Quaternion.AngleAxis(90, Vector3.up);
            case SocketPosition.Rear: return Quaternion.AngleAxis(180, Vector3.up);

            default:
                print("Unknown SocketPosition value: " + position);
                return Quaternion.identity;
        }
    }

    #endregion
}
