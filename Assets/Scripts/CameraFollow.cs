using System;
using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform pos1;
    public Transform pos2;
    public Transform lookAt;

    void Update()
    {
        
        transform.LookAt(lookAt);
    }
/*
    public void SwitchCameraPosition()
    {
        if (player.transform.GetComponent<PlayerMovement>().isWolf)
        {
            transform.position = pos1.position;
        }
        else transform.position = pos2.position;
    }*/
}
