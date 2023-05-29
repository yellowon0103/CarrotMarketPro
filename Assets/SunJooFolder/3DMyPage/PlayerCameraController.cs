using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//rotates player and camera according to mouse movement
public class PlayerCameraController : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //restrict xRotation -90 ~ 90

        //rotate camera
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //rotate player
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


    }
}
