using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;

    public float mouseSensitivity;

    float xRotation = 0;

    //Less value on zoomMax is to zoom IN
    public float zoomMax;

    float zoomValue = 59;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        //Cursor state stay on the middle screen
        //Cursor is Invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        //Get X and Y of mouse axis multiply with the given mouse sensitivity value
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate playerbody on the x Axis
        playerBody.Rotate(Vector3.up * mouseX);

        //Mouse vertical rotation(Camera only rotation doesn't effect player)
        //Clamping/Limit the vertical camera rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        zoomValue = Mathf.Clamp(zoomValue, zoomMax, 59f);

        //Rotate camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Zoom Camera
        if(Input.GetMouseButton(1))
        {
            zoomValue--;
        }
        else
        {
            zoomValue++;
        }

        //Change the value of camera fieldOfView to zoomValue
        cam.fieldOfView = zoomValue;

        

    }
}
