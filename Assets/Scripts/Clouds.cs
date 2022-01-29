using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject pivot;
    public float rotationSpeed = 20f;

    private void Awake()
    {
        pivot = GameObject.FindGameObjectWithTag("CloudPivot");
    }
    void Update()
    {
        transform.RotateAround(pivot.transform.position,new Vector3(0,1,0),rotationSpeed * Time.deltaTime);
        transform.LookAt(pivot.transform);
    }
}
