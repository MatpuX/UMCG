using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectMove : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 startPos;
    private float elapsed = 0;
    private float travelTime = 2;
    private Vector3 newTarget; 
    private bool canMove;

    // Start is called before the first frame update
    private void OnEnable()
    {
        
        _rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        //targetPos = HandL.transform.position;
        

    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            newTarget = NetBehaviour.Instance.RandomTarget();
            Debug.Log("New target " + newTarget);
            canMove = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!canMove) return;
        //Debug.Log("Target" + targetPos);
        elapsed += Time.fixedDeltaTime;
        float t = (travelTime <= 0.0001f) ? 1f : Mathf.Clamp01(elapsed / travelTime);
        Vector3 nextPos = Vector3.Lerp(startPos, newTarget, t);
        
        _rb.MovePosition(nextPos);
    }

}
