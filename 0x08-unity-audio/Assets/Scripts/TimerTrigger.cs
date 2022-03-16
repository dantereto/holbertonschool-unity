using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    void OnTriggerExit(Collider other) {
        player.GetComponent<Timer>().enabled = true;   
        anim.SetBool("falling", false);     
    }
}
