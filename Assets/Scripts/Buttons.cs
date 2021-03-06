using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject instructions;
    public bool instructionOpen=false;
    // Start is called before the first frame update
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Instructions()
    {
        instructionOpen = !instructionOpen;
        instructions.SetActive(instructionOpen);
    }
    
}
