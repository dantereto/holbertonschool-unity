using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource grassStepSFX;
    public AudioSource grassLandSFX;
    private bool is_ground = true;
    public float speed = 2.1f;
    private Vector3 velocity = Vector3.zero;
    public CharacterController charc;
    private float gravity = -9.8f;
    public float max_jump = 2f;
    public Animator anim;
    public bool check = false;
    // Update is called once per frame
    void Start() {
    }
    void Update()
    {
        is_ground = charc.isGrounded;
        if (is_ground && velocity.y < 0)
        {
            velocity.y = 0f;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Running") && (grassStepSFX.isPlaying) == false)
                grassStepSFX.Play();
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Falling Flat Impact") && check == false)
            {
                grassLandSFX.Play();
                check = true;
                check = false;
            }    
        }
        else
        is_ground = charc.isGrounded;
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");
        float dist = speed * Time.deltaTime;
        Vector3 move = (transform.right * xDirection + transform.forward * yDirection);
        charc.Move(move * speed * Time.deltaTime);
        float temp = (Mathf.Max(move.x, move.y, move.z));
        if (temp != 0)
            anim.SetBool("running", true);
        else
            anim.SetBool("running", false);
        if (Input.GetKey(KeyCode.Space) && is_ground)
        {
            velocity.y += Mathf.Sqrt(max_jump * -2f * gravity);
            anim.SetBool("jumping", true);
        }   
        else
            anim.SetBool("jumping", false);
        velocity.y += gravity * Time.deltaTime;
        charc.Move(velocity * Time.deltaTime);
        if (transform.position.y < -30)
        {
            anim.SetBool("falling", true);
            transform.position = new Vector3 (0, 80, 0);
            if (anim.GetBool("falling") == false)
                anim.SetBool("falling", false);
        }
    }
}
     