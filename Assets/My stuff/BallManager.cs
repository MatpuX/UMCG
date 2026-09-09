using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [Header("Ball Pool")]
    [SerializeField] private BallBehaviour ballPrefab;
    [SerializeField] private int poolSize = 10;

    [Header("Spawn Area")]
    [SerializeField] private BoxCollider spawnArea;

    [Header("Ball Settings")]
    [SerializeField] private float ballSpeed = 100f;

    private List<BallBehaviour> ballPool = new List<BallBehaviour>();

    private void Start()
    {
        
        if(spawnArea == null)
        {
            spawnArea = GetComponent<BoxCollider>();
        }
        CreatePool();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchRandomBall();
        }
    }

    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            BallBehaviour ball = Instantiate(ballPrefab);

            ball.gameObject.SetActive(false);

            ballPool.Add(ball);
        }
    }

    private void LaunchRandomBall()
    {
        BallBehaviour ball = GetBall();

        if (ball == null)
            return;

        Vector3 spawnPosition = GetRandomSpawnPosition();
        float radius = ball.GetRadius();

        Vector3 targetPosition = NetBehaviour.Instance.RandomTarget(radius);

        ball.gameObject.SetActive(true);

        ball.Launch(
            spawnPosition,
            targetPosition,
            ballSpeed
        );

        Debug.Log(
            $"Ball launched from {spawnPosition} " +
            $"to {targetPosition}"
        );
    }

    private BallBehaviour GetBall()
    {
        foreach (BallBehaviour ball in ballPool)
        {
            if (!ball.gameObject.activeSelf)
            {
                return ball;
            }
        }

        Debug.LogWarning("No available balls in pool!");
        return null;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Bounds bounds = spawnArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(x, y, z);
    }
}