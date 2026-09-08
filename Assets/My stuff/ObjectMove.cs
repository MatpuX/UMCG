using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectMove : MonoBehaviour
{
    public Rigidbody _rb;
    private Vector3 startPos;
    private Vector3 targetPos;
    public GameObject HandL;
    private float elapsed = 0;
    private float travelTime = 2;
    private bool canMove;

    // Start is called before the first frame update
    private void OnEnable()
    {
        
        _rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        //targetPos = HandL.transform.position;
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!NetBehaviour.Instance.canMove) return;
        //Debug.Log("Target" + targetPos);
        elapsed += Time.fixedDeltaTime;
        float t = (travelTime <= 0.0001f) ? 1f : Mathf.Clamp01(elapsed / travelTime);
        Vector3 nextPos = Vector3.Lerp(startPos, NetBehaviour.Instance.newTarget, t);
        
        _rb.MovePosition(nextPos);
    }

}
