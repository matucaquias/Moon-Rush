using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform pos1;
    public Transform pos2;
    public Transform lookAt;
    
    // Update is called once per frame
    void Update()
    {
        /*Vector3 targetPos = player.position + _offset;
        targetPos.x = 0;
        transform.position = targetPos;*/
        transform.LookAt(lookAt);
    }

    public void SwitchCameraPosition()
    {
        if (player.transform.GetComponent<PlayerMovement>().isWolf)
        {
            transform.position = pos1.position;
        }
        else transform.position = pos2.position;
    }
}
