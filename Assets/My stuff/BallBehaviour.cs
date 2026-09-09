using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private float elapsedTime;
    private float travelTime;

    private bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 start, Vector3 target, float speed)
    {
        startPosition = start;
        targetPosition = target;

        float distance = Vector3.Distance(start, target);
        travelTime = distance / speed;

        elapsedTime = 0f;
        isMoving = true;

        transform.position = start;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (!isMoving)
            return;

        elapsedTime += Time.fixedDeltaTime;

        float t = travelTime <= 0.0001f? 1f: Mathf.Clamp01(elapsedTime / travelTime);

        Vector3 nextPosition = Vector3.Lerp(startPosition,targetPosition,t);

        rb.MovePosition(nextPosition);

        if (t >= 1f)
        {
            Stop();
        }
    }

    public void Stop()
    {
        isMoving = false;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        gameObject.SetActive(false);
    }
    public float GetRadius()
    {
        SphereCollider sphere = GetComponent<SphereCollider>();

        return sphere.radius * transform.lossyScale.x;
    }
}