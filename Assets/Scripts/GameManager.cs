using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject moon;
    public float transformationCounter; //tiempo que demora la transformacion.
    public bool isWolf; // la vamos a usar cuando choca con cosas, para restablecer luego los stats.
    public bool canTransform;  // con esta variable se accede al comienzo de la transformacion.
    // Start is called before the first frame update
    
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!moon.GetComponent<MoonChecker>().isClouded && canTransform)
        {
            player.GetComponent<PlayerMovement>().speed = 0;
            transformationCounter += Time.deltaTime;
            if(transformationCounter >= 1)
            {
                isWolf = true;
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
            if (transformationCounter >= 1)
            {
                isWolf = false;
                Transformation();
                transformationCounter = 0;
                canTransform = false;
            }
        }
        
    }

    public void Transformation()
    {
        if (isWolf)  // modo lobo
        {
            player.GetComponent<PlayerMovement>().speed = 4;
            player.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else  // modo humano
        {
            player.GetComponent<PlayerMovement>().speed = 1;
            //player.transform.eulerAngles = new Vector3(0, 180, 0);  Agregar luego de tener el mapa procedural bien
        }
    }
    
}
