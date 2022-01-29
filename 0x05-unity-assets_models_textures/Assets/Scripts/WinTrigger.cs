using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Text TimerText;
    void OnTriggerExit(Collider other) {
        player.GetComponent<Timer>().enabled = false;
        TimerText.color = Color.green;
        TimerText.fontSize = 60;
    }

}

