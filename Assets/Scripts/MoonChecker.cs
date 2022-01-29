using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonChecker : MonoBehaviour
{
    public LayerMask mask;
    public bool isClouded;
    public float checkRadius;

    private void FixedUpdate()
    {
        CheckIfClouded();
    }

    void CheckIfClouded()
    {
        isClouded = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, mask);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isClouded = true;
            }
        }
    }
}
