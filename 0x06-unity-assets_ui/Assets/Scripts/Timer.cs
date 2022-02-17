using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool stop = false;
    public Text TimerText;
    public Text WinText;
    private float totalT = 0f;
    // Start is called before the first frame update

    // Update is called once per frame
    public void Stop() 
    {
        this.stop = true;
        this.TimerText.color = Color.green;
        this.TimerText.fontSize = 60;
    }
    public void Win()
    {
        WinText.text = TimerText.text;
        TimerText.text = "";
    }
    void Update() {
        if (this.stop == false)
            totalT += Time.deltaTime;
            TimerText.text = $"{(int)totalT / 60}:{(totalT % 60).ToString("00.00")}";
    }
}
