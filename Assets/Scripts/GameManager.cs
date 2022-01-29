using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public GameObject player;
    public int speed;
    public bool moon = false; //sustituir luego por script de luna
    // Start is called before the first frame update
    
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (moon)
        {
            player.GetComponent<PlayerMovement>().speed = 4;
        }
        else
        {
            player.GetComponent<PlayerMovement>().speed = 1;
        }
    }
    
}
