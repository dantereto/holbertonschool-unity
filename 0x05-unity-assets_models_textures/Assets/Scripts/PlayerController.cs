using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hold;
    private bool is_ground = true;
    public float speed = 2.1f;
    public Vector3 velocity;
    public CharacterController charc;
    private float gravity = -9.8f;
    public float max_jump = 2f;
    // Update is called once per frame
    void Update()
    {
        is_ground = charc.isGrounded;
        if (is_ground && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        is_ground = charc.isGrounded;
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(xDirection, 0.0f, yDirection);
        charc.Move(move * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) && is_ground)
        {
            velocity.y += Mathf.Sqrt(max_jump * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        charc.Move(velocity * Time.deltaTime);
        if (transform.position.y < -30)
        {
            transform.position = new Vector3 (0, 30, 0);
        }
    }
}
