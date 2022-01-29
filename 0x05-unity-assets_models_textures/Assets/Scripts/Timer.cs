using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float startT;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        this.TimerText.text = string.Format("{0}:{1:00.00}",
        Mathf.RoundToInt(Time.time / 60), Time.time % 60
        );
    }
}
