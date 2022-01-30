using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonChecker : MonoBehaviour
{
    public LayerMask mask;
    public bool isClouded;
    public float checkRadius;
    public bool oneTime;
    public GameManager gm;
    private void FixedUpdate()
    {
        CheckIfClouded();
    }

    void CheckIfClouded()
    {
        isClouded = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, mask);
//        Debug.Log("colliders" + colliders.Length);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isClouded = true;
            }
        }
        if(colliders.Length == 0 && oneTime) //esto lo hice para que solo pueda transformarase una vez, cuadno entra y sale la nube
        {
            gm.canTransform = true;
            oneTime = false;
        }
        if(colliders.Length > 0 && !oneTime)
        {

            gm.canTransform = true;
            oneTime = true;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,checkRadius);
    }
}
