using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject moon;
    public float transformationCounter; //tiempo que demora la transformacion.
    public bool canTransform;  // con esta variable se accede al comienzo de la transformacion.
    public GameObject playerMesh;

    public int remainingEnemies;

    public AudioMixerSnapshot snapshotHombre;
    public AudioMixerSnapshot snapshotLobo;

    public AudioSource audioSource;
    public AudioClip lobo;
    public AudioClip hombre;
    
    
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    void Update()
    {
        remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (remainingEnemies == 0)
        {
            SceneManager.LoadScene("Win");
        }
        
        if (!moon.GetComponent<MoonChecker>().isClouded && canTransform)
        {
            player.GetComponent<PlayerMovement>().psjeAnim.SetTrigger("Transform");
            player.GetComponent<PlayerMovement>().speed = 0;
            transformationCounter += Time.deltaTime;
            if(transformationCounter >= 2f)
            {
                player.GetComponent<PlayerMovement>().isWolf = true;
                Transformation();
                transformationCounter = 0;
                canTransform = false;
                snapshotLobo.TransitionTo(0.1f);
                audioSource.PlayOneShot(lobo);
            }
        }
        else if (moon.GetComponent<MoonChecker>().isClouded && canTransform)
        {
            //            Debug.Log("entra");
            player.GetComponent<PlayerMovement>().wolfAnim.SetTrigger("Transform");

            player.GetComponent<PlayerMovement>().speed = 0;
            transformationCounter += Time.deltaTime;
            if (transformationCounter >= 2f)
            {
                player.GetComponent<PlayerMovement>().isWolf = false;
                Transformation();
                transformationCounter = 0;
                canTransform = false;
                snapshotHombre.TransitionTo(0.1f);
                audioSource.PlayOneShot(hombre);
            }
        }
        
    }

    public void Transformation()
    {
        if (player.GetComponent<PlayerMovement>().isWolf)  // modo lobo
        {
            player.GetComponent<PlayerMovement>().speed = player.GetComponent<PlayerMovement>().wolfSpeed;
            playerMesh.transform.eulerAngles = new Vector3(0, 180, 0);
            player.GetComponent<PlayerMovement>().psjeAnim.gameObject.SetActive(false);
            player.GetComponent<PlayerMovement>().wolfAnim.gameObject.SetActive(true);

            //StartCoroutine(WaitFunc(3));
            //FindObjectOfType<CameraFollow>().SwitchCameraPosition();
        }
        else  // modo humano
        {
            //FindObjectOfType<CameraFollow>().SwitchCameraPosition();
            player.GetComponent<PlayerMovement>().speed = player.GetComponent<PlayerMovement>().humanSpeed;
            player.GetComponent<PlayerMovement>().wolfAnim.gameObject.SetActive(false);
            player.GetComponent<PlayerMovement>().psjeAnim.gameObject.SetActive(true);

            playerMesh.transform.eulerAngles = new Vector3(0, 0, 0);  
        }
    }
    /*
    IEnumerator WaitFunc(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }*/
}
