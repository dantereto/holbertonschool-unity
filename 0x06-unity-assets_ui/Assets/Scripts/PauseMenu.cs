using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Canvas;
    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (!paused)
            {
                Pause();
            }
            if (paused)
            {
                Resume();
            }
        }
    }
    // Pause the game
    public void Pause()
    {
        Time.timeScale = 0;
        Canvas.SetActive(true);
    }
    // Resume the game
    public void Resume()
    {
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }
    // restart the game
    public void Restart()
    {
        var level = SceneManager.GetActiveScene().name;
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }
    // Go to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Options menu
    public void Options()
    {
        SceneManager.LoadScene("Options");   
    }
}
