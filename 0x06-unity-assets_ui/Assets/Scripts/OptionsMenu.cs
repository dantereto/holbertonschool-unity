using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{https://github.com/dantereto/holbertonschool-unity/blob/main/0x06-unity-assets_ui/Assets/Scripts/OptionsMenu.cs
    public Toggle invertedMode;
    void Start()
    {
        if (PlayerPrefs.GetInt("Inverted") == 1)
            invertedMode.isOn = true;
        else
            invertedMode.isOn = false;
    }
    //  Go back
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    // make the changes
    public void Apply()
    {
        if (invertedMode.isOn == true)
            PlayerPrefs.SetInt("Inverted", 1);
        else
            PlayerPrefs.SetInt("Inverted", 0);
        Back();
    }
}
