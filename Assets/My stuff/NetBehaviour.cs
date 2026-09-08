using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    private float netHeight;
    private float netWidth;
    private Vector3 netMin;
    private Vector3 netMax;
    private Vector3 newTarget;
    public static NetBehaviour Instance { get; private set; }

    void Start()
    {
        Instance = this;
        netWidth = this.gameObject.transform.localScale.x / 2;
        netHeight = this.gameObject.transform.localScale.y / 2;

        //capture the returned bounds
        (netMin, netMax) = CalculateNetBounds(this.gameObject.transform.position, netHeight, netWidth);

        Debug.Log("Net bounds: " + netMin + " to " + netMax);
    }

    public (Vector3 min, Vector3 max) CalculateNetBounds(Vector3 center, float height, float width)
    {
        Vector3 min = center;
        Vector3 max = center;

        min.x -= width;
        min.y -= height;
        max.x += width;
        max.y += height;

        return (min, max);
    }

    public Vector3 RandomTarget(Vector3 minBound, Vector3 maxBound)
    {
        float x = Random.Range(minBound.x, maxBound.x);
        float y = Random.Range(minBound.y, maxBound.y);
        float z = -2; // will just be center.z if you don't expand z
        return new Vector3(x, y, z);
    }

    void Update()
    {
        
        
        /*
        if (Input.GetKeyDown("space"))
        {
            newTarget = RandomTarget(netMin, netMax);
            Debug.Log("New target " + newTarget);
        }
        */
    }
}