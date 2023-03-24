using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 2.0f;
    public float mouseSpeed = 1.0f;
    private Vector2 mouse;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouse.x += Input.GetAxis("Mouse X") * mouseSpeed;
        mouse.y += Input.GetAxis("Mouse Y") * mouseSpeed;
        transform.localRotation = Quaternion.Euler(-mouse.y, mouse.x, 0);


        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime);

        }
    }
}
