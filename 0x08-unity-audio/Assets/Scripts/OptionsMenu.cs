using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertedMode;
    void Start()
    {
        if (PlayerPrefs.GetInt("Inverted") == 1)
            invertedMode.isOn = true;
        else
            invertedMode.isOn = false;
    }
    // Go back
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    // Apply changes
    public void Apply()
    {
        if (invertedMode.isOn == true)
            PlayerPrefs.SetInt("Inverted", 1);
        else
            PlayerPrefs.SetInt("Inverted", 0);
        Back();
    }
}
