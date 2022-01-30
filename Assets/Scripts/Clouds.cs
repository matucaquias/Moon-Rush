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
        transform.RotateAround(pivot.transform.position,Vector3.up, rotationSpeed * Time.deltaTime);
        transform.LookAt(pivot.transform);
    }
}
