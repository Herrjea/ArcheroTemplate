using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(FacePlayer))]
[RequireComponent(typeof(FaceVelocity))]

public class Charger : EnemyMovement
{
    [SerializeField] protected AnimationCurve movementEase = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField] protected float movementDuration = 4;
    [SerializeField] protected float chargeCD = 3;

    protected Transform player;
    protected Vector3 targetPosition;

    WaitForSeconds CDTimer;

    FacePlayer facePlayerRotation;
    FaceVelocity faceVelocityRotation;


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        CDTimer = new WaitForSeconds(chargeCD);

        facePlayerRotation = GetComponent<FacePlayer>();
        faceVelocityRotation = GetComponent<FaceVelocity>();
        SwitchToFacePlayer();

        StartCoroutine(ChargeTrigger());
    }

    
    IEnumerator ChargeTrigger()
    {
        while (gameObject.activeSelf)
        {
            // Start the CD and wait for it to finish
            yield return CDTimer;

            // Get the targetPosition needed for the charge
            targetPosition = ComputeTargetPosition();

            // Move to that position
            SwitchToFaceVelocity();
            yield return StartCoroutine(MoveToTarget());

            // Teleport above the screen
            transform.position = new Vector3(
                0,
                transform.position.y,
                roomSize.y * 2
            );

            // Move to a random position in the screen's upper half
            targetPosition = new Vector3(
                Random.Range(-roomSize.x, roomSize.x),
                transform.position.y,
                Random.Range(0, roomSize.y * 0.7f)
            );
            SwitchToFacePlayer();
            yield return StartCoroutine(MoveToTarget());
        }
    }


    Vector3 ComputeTargetPosition()
    {
        return
            (player.position - transform.position).normalized
            *
            roomSize.y * 2;
    }


    protected IEnumerator MoveToTarget()
    {
        float elapsed = 0;
        Vector3 startingPosition = transform.position;

        while (elapsed < movementDuration && gameObject.activeSelf)
        {
            elapsed += Time.deltaTime;

            transform.position = Vector3.Lerp(
                startingPosition,
                targetPosition,
                movementEase.Evaluate(elapsed / movementDuration)
            );

            yield return null;
        }
    }

    protected void SwitchToFaceVelocity()
    {
        facePlayerRotation.enabled = false;
        faceVelocityRotation.enabled = true;
    }

    protected void SwitchToFacePlayer()
    {
        faceVelocityRotation.enabled = false;
        facePlayerRotation.enabled = true;
    }
}
