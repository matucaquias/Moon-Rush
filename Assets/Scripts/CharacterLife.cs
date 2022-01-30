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
    // Start is called before the first frame update
    void Start()
    {
        InstantiateHearths();
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
            counterToDie += Time.deltaTime;            
            if (counterToDie >= 3)
            {
                SceneManager.LoadScene("RestartScene");
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
        lifeCount -= dmg;
        this.GetComponent<PlayerMovement>().SlowsDown();
        
        for (int x = lifeCount;x < hearts.Count; x++)
        {
            if(x >= 0)  // sin esto buscaria en el -1 de la lista, da error.
            {
                hearts[x].enabled = false;
                Debug.Log("WAT" + x);

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
    }
}
