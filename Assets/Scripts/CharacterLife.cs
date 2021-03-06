using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterLife : MonoBehaviour
{
    public List<Image> hearts;
    public int lifeCount;
    public float counterToDie;
    public Animator psjeAnim;
    public Animator wolfAnim;

    public AudioSource audioSource;
    public AudioClip hurt;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateHearths();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // esto es de prueb SACAR AL TERMINAR.
        {
            Damage(2);
        }
        if(lifeCount <= 0)  //Delay luego de muerte, para agregar animacion o algo
        {
           
            if (lifeCount == 0)
            {
              
                lifeCount -= 1;

            }
            counterToDie += Time.deltaTime;            
            if (counterToDie >= 3)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }
    public void InstantiateHearths()  //Activa los corazones al empezar la partida.
    {
        for (int x = 0; x< hearts.Count; x++)
        {
            hearts[x].enabled = true;
        }
    }
    public void Damage(int dmg)   // Recibe el daño del enemigo u objeto del mapa
    {
        if (!gm.canTransform)
        {
            lifeCount -= dmg;
            this.GetComponent<PlayerMovement>().SlowsDown();
            audioSource.PlayOneShot(hurt);
            if (lifeCount <= 0)
            {
                psjeAnim.SetTrigger("Die");
                wolfAnim.SetTrigger("Die");
            }
            for (int x = lifeCount; x < hearts.Count; x++)
            {
                if (x >= 0)  // sin esto buscaria en el -1 de la lista, da error.
                {
                    hearts[x].enabled = false;
                    Debug.Log("WAT" + x);

                }

            }
        }
        

    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Trap")
        {
            Debug.Log("trigg");

            Damage(other.GetComponent<Traps>().dmg);
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Bullet")
        {
            Damage(other.GetComponent<Proyectile>().dmg);
            Destroy(other.gameObject);
        }
    }
}
