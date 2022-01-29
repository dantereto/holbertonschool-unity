 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 5f;
    public Transform player;
    public Vector3 offset;
    void Start() {
        offset = transform.position -player.position;
    }
    // Update is called once per frame
    void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSensitivity, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
        player.Rotate(Input.GetAxis("Mouse X") * mouseSensitivity * Vector3.up);
    }
}
