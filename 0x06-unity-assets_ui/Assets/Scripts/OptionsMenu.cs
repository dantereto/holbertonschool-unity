using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class OptionsMenu : MonoBehaviour
{
    public Toggle isInverted;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("isInverted") == 1)
            isInverted.isOn = true;
        else    
            isInverted.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Apply()
    {
        if (isInverted.isOn)
            PlayerPrefs.SetInt("Inverted", 1);
        else
            PlayerPrefs.SetInt("Inverted", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
