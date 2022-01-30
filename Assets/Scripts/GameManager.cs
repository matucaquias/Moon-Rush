using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject moon;
    public float transformationCounter; //tiempo que demora la transformacion.
    public bool canTransform;  // con esta variable se accede al comienzo de la transformacion.
    public GameObject playerMesh;
    
    void Update()
    {
        if (!moon.GetComponent<MoonChecker>().isClouded && canTransform)
        {
            player.GetComponent<PlayerMovement>().psjeAnim.SetBool("Transform", true);
            player.GetComponent<PlayerMovement>().speed = 0;
            transformationCounter += Time.deltaTime;
            if(transformationCounter >= 1f)
            {
                player.GetComponent<PlayerMovement>().isWolf = true;
                Transformation();
                transformationCounter = 0;
                canTransform = false;
            }
        }
        else if (moon.GetComponent<MoonChecker>().isClouded && canTransform)
        {
            Debug.Log("entra");
            player.GetComponent<PlayerMovement>().speed = 0;
            transformationCounter += Time.deltaTime;
            if (transformationCounter >= 1f)
            {
                player.GetComponent<PlayerMovement>().isWolf = false;
                Transformation();
                transformationCounter = 0;
                canTransform = false;
            }
        }
        
    }

    public void Transformation()
    {
        if (player.GetComponent<PlayerMovement>().isWolf)  // modo lobo
        {
            player.GetComponent<PlayerMovement>().speed = -0.04f;
            playerMesh.transform.eulerAngles = new Vector3(0, 180, 0);
            //StartCoroutine(WaitFunc(3));
            //FindObjectOfType<CameraFollow>().SwitchCameraPosition();
            player.GetComponent<PlayerMovement>().psjeAnim.SetBool("Transform", false);
        }
        else  // modo humano
        {
            //FindObjectOfType<CameraFollow>().SwitchCameraPosition();
            player.GetComponent<PlayerMovement>().speed = 0.02f;
            playerMesh.transform.eulerAngles = new Vector3(0, 0, 0);  
        }
    }
    /*
    IEnumerator WaitFunc(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }*/
}
