using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraLook : MonoBehaviour
{
    public float sensitivity;

    public GameObject playerBody, mainCamPos, straveLocRObj, straveLocLObj;

    float xRotation, zRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, zRotation);
        playerBody.transform.Rotate(Vector3.up * mouseX);

        if (Input.GetButtonDown("StraveR") && !Input.GetButtonDown("StraveL"))
        {
            transform.position = straveLocRObj.transform.position;
            zRotation = -10;
        }
        if (Input.GetButtonUp("StraveR"))
        {
            transform.position = mainCamPos.transform.position;
            zRotation = 0;
        }
        if (Input.GetButtonDown("StraveL") && !Input.GetButtonDown("StraveR"))
        {
            transform.position = straveLocLObj.transform.position;
            zRotation = 10;
        }
        if (Input.GetButtonUp("StraveL"))
        {
            transform.position = mainCamPos.transform.position;
            zRotation = 0;
        }
    }
}
