using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTest : Hittable
{
    public override void Hit(Hitter hitter) 
    {
        Debug.Log("I have been intercepted");
        Destroy(this.gameObject);
    }
}
