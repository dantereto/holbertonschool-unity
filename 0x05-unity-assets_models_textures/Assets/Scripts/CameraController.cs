using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 5f;
    public Vector2 mouse;
    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        mouse.x += Input.GetAxis("Mouse X");
        mouse.y += Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(-mouse.y, mouse.x, 0);
    }
}
