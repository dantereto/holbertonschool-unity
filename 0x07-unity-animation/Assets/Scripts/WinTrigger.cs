using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Text TimerText;
    public GameObject Canvas;
    void OnTriggerExit(Collider other) {
        player.GetComponent<Timer>().Stop();
        Canvas.SetActive(true);
    }
}

