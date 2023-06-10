using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 2.0f;
    public float mouseSpeed = 1.0f;
    private int shootType = 0; // 0 for condence, 1 for wide, 2 for full
    List<bool> keyCodeList = new List<bool>(); //A - 1, D - 2, W - 3, S - 4
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void mouseWheelScroll(int dir)
    {
        shootType += (dir > 0 ? 1 : -1);
        if (shootType > 2)
        {
            shootType = 0;
        }
        else if (shootType < 0) {
            shootType = 2;
        }
    }
    
    void mouseMovement(Vector2 mouse)
    {
        transform.localRotation = Quaternion.Euler(-mouse.y, mouse.x, 0);
    }

    void cameraMovement(List<bool> keyboard)
    {
        keyCodeList = keyboard;
    }

    void OnEnable()
    {
        InputManager.OnMouseWheelScroll += mouseWheelScroll;
        InputManager.OnDisplacement += mouseMovement;
        InputManager.OnKeyBoardInput += cameraMovement;
    }


    // Update is called once per frame
    void Update()
    {   
        if (keyCodeList[0])
        {
            this.gameObject.transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }
        else if (keyCodeList[1])
        {
            this.gameObject.transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);

        }
        if (keyCodeList[2])
        {
            this.gameObject.transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime);

        }
        else if (keyCodeList[3])
        {
            this.gameObject.transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime);

        }


    }


}
