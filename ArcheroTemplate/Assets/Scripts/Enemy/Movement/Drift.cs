using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : EnemyMovement
{
    [SerializeField] Vector2 angleRange = new Vector2(10, 50);
    [SerializeField] Vector2 speedRange = new Vector2(1, 2);
    [SerializeField] bool moveTowardsCenerOfScreen = true;

    Vector3 velocity;


    protected override void Awake()
    {
        base.Awake();

        float angle = Random.Range(angleRange.x, angleRange.y) * Mathf.Deg2Rad;
        float speed = Random.Range(speedRange.x, speedRange.y);

        velocity =
            new Vector3(
                Mathf.Cos(angle),
                0,
                Mathf.Sin(angle)
            ).normalized
            *
            speed;

        // Make it travel towards the horizontal center of the screen
        if (moveTowardsCenerOfScreen)
        {
            if (transform.position.x < 0)
                velocity.x = Mathf.Abs(velocity.x);
            else
                velocity.x = -Mathf.Abs(velocity.x);
        }
    }


    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
