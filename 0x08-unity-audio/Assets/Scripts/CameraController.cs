using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 4f;
    public Transform player;
    public Vector3 offset;
    public bool isInverted = false;
    private int Inverted = 1;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
        if (Inverted == -1)
            isInverted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInverted)
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSensitivity, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * Inverted * mouseSensitivity, Vector3.right) * offset;
        else 
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSensitivity, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * Inverted * mouseSensitivity, Vector3.left) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
        player.Rotate(Input.GetAxis("Mouse X") * mouseSensitivity * Vector3.up);
    }
}