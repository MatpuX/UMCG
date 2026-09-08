using System;
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
    
    
    public static NetBehaviour Instance { get; private set; }

    void Start()
    {
        Instance = this;
        netWidth = this.gameObject.transform.localScale.x / 2;
        netHeight = this.gameObject.transform.localScale.y / 2;

        //capture returned bounds
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

    public Vector3 RandomTarget()
    {
        float x = UnityEngine.Random.Range(netMin.x, netMax.x);
        float y = UnityEngine.Random.Range(netMin.y, netMax.y);
        float z = -2;
        
        return new Vector3(x, y, z);
        
    }

    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Scored");
            Destroy(other.gameObject);
        }
    }
}