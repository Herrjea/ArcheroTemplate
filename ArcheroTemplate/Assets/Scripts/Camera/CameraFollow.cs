using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;

    [SerializeField] Vector3 offset = new Vector3(0, 20, 0);
    [SerializeField] float speedSmooth = 2;

    [SerializeField] Vector2 positionClamp = new Vector2(20, 30);

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

        // Follow the target
        transform.position =
            Vector3.Lerp(
                ownPositionFlattened,
                target.position,
                speedSmooth * Time.deltaTime
            )
            +
            offset;

        // Limit camera's movement
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -positionClamp.x, positionClamp.x),
            transform.position.y,
            Mathf.Clamp(transform.position.z, -positionClamp.y, positionClamp.y)
        );
    }
}
