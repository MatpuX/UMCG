using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    public static NetBehaviour Instance { get; private set; }

    [SerializeField] private BoxCollider targetArea;

    private void Awake()
    {
        Instance = this;

        if (targetArea == null)
        {
            targetArea = GetComponent<BoxCollider>();
        }
    }

    public Vector3 RandomTarget(float ballRadius = 0f)
    {
        Bounds bounds = targetArea.bounds;

        float x = Random.Range(
            bounds.min.x + ballRadius,
            bounds.max.x - ballRadius
        );

        float y = Random.Range(
            bounds.min.y + ballRadius,
            bounds.max.y - ballRadius
        );

        //keep the target at the front/back surface you want.
        float z = bounds.center.z;

        return new Vector3(x, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Scored");
        }
    }
}