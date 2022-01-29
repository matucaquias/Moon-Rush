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
        if (Input.GetKeyDown(KeyCode.F))
        {
            Damage(2);
        }
        if(lifeCount <= 0)
        {
            counterToDie += Time.deltaTime;
            if (counterToDie >= 3)
            {
                SceneManager.LoadScene("RestartScene");
            }
        }
    }
    public void InstantiateHearths()
    {
        for (int x = 0; x< hearts.Count; x++)
        {
            hearts[x].enabled = true;
        }
    }
    public void Damage(int dmg)
    {
        lifeCount -= dmg;
       
        for (int x = lifeCount;x < hearts.Count; x++)
        {
            if(x >= 0)
            {
                hearts[x].enabled = false;
                Debug.Log("WAT" + x);

            }
            
        }

    }
}
