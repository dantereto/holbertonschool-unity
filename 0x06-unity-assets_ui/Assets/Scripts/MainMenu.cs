using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool buttonPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Select the level
    public void LevelSelect(int level)
    {
        if (level == 1)
        {
            SceneManager.LoadScene("Level01");
            Time.timeScale = 1;
        }
        if (level == 2)
        {
            SceneManager.LoadScene("Level02");
            Time.timeScale = 1;
        }
        if (level == 3)
        {
            SceneManager.LoadScene("Level03");
            Time.timeScale = 1;
        }
    }
    // Options menu
    public void Options(string level)
    {
        SceneManager.LoadScene("Options");
    }
    // Exit button
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
