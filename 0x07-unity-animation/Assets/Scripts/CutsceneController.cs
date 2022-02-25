using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject TimerCanvas;
    public PlayerController playerS;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            MainCamera.SetActive(true);
            playerS.enabled = true;
            TimerCanvas.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
