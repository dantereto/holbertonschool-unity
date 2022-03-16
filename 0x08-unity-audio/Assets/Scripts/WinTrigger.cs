using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class WinTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Text TimerText;
    public GameObject Canvas;
    public AudioSource cherry_audio;
    public AudioSource piano_audio;
    void OnTriggerExit(Collider other) {
        player.GetComponent<Timer>().Stop();
        Canvas.SetActive(true);
        cherry_audio.Stop();
        piano_audio.Play();
    }
}


