using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;



public class InputManager : MonoBehaviour
{
    private Vector2 mouse;
    private Vector2 mouseLast;
    List<bool> keyCodeList; //A - 1, D - 2, W - 3, S - 4
    List<bool> keyCodeListLast;

    public delegate void MouseWheelScrollHandler(int dir);
    public static event MouseWheelScrollHandler OnMouseWheelScroll;
    public delegate void MouseDisplacementHandler(Vector2 mousePos);
    public static event MouseDisplacementHandler OnDisplacement;
    public delegate void KeyBoardInput(List<bool> inputs);
    public static event KeyBoardInput OnKeyBoardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keyCodeList = new List<bool>();
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        mouse.x += Input.GetAxis("Mouse X");
        mouse.y += Input.GetAxis("Mouse Y");

        if (scrollWheel != 0f)
        {
            if (OnMouseWheelScroll != null)
            {
                OnMouseWheelScroll.Invoke((int)(scrollWheel * 10));
            }
        }

        if (mouse != mouseLast)
        {
            OnDisplacement(mouse);
            mouseLast = mouse;
        }
        keyCodeList.Add((Input.GetKey(KeyCode.A) == true ? true : false));
        keyCodeList.Add((Input.GetKey(KeyCode.D) == true ? true : false));
        keyCodeList.Add((Input.GetKey(KeyCode.W) == true ? true : false));
        keyCodeList.Add((Input.GetKey(KeyCode.S) == true ? true : false));

        if (keyCodeList != keyCodeListLast)
        {
            keyCodeListLast = keyCodeList;
            OnKeyBoardInput(keyCodeList);
        }

    }

}
