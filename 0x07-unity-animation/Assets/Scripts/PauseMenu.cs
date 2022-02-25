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
    public void Pause()
    {
        Canvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        var level = SceneManager.GetActiveScene().name;
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Options()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Options");   
    }
}
