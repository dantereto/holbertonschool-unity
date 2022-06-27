using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public GameObject Canvas;
    private bool paused;
    public AudioMixerSnapshot pause;
    public AudioMixerSnapshot unpause;
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
    // Pause game
    public void Pause()
    {
        Canvas.SetActive(true);
        pause.TransitionTo(0f);
        Time.timeScale = 0;
    }
    // Resume game
    public void Resume()
    {
        Canvas.SetActive(false);
        unpause.TransitionTo(0f);
        Time.timeScale = 1;
    }
    // Restart game
    public void Restart()
    {
        var level = SceneManager.GetActiveScene().name;
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }
    // Main menu
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    // Options menu
    public void Options()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Options");   
    }
}
