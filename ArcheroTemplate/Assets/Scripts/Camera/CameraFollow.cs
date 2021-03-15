using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;

    [SerializeField] Vector3 offset = new Vector3(0, 20, 0);
    [SerializeField] float speedSmooth = .08f;

    Vector3 ownPositionFlattened;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        transform.position = target.position + offset;
    }


    void FixedUpdate()
    {
        ownPositionFlattened = transform.position;
        ownPositionFlattened.y = target.position.y;

        transform.position =
            Vector3.Lerp(
                ownPositionFlattened,
                target.position,
                speedSmooth
            );
        transform.position += offset;
    }
}
