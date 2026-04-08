using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float horizontalSensitivity = 30.0f; // The horizontal sensitivity of the camera
    public float verticalSensitivity = 30.0f; // The vertical sensitivity of the camera

    private float horiRotation = 0.0f; // The camera's horizontal rotation
    private float vertRotation = 0.0f; // The camera's vertical rotation

    public float vertMovement = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Hide the cursor and lock it inside the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    

    // Update is called once per frame
    void Update()
    {
        // Get input from the mouse and move the camera in the X and Y direction
        horiRotation += horizontalSensitivity * Input.GetAxis("Mouse X");
        vertRotation -= verticalSensitivity * Input.GetAxis("Mouse Y");

        // If the camera tries to look more than straight up set camera to vertical
        if (vertRotation >= 90.0f)
        {
            vertRotation = 90.0f;
        }

        // If the camera tries to look more than straight down set camera to vertical
        if (vertRotation <= -90.0f) {
            vertRotation = -90.0f;
        }

        transform.eulerAngles = new Vector3(vertRotation, horiRotation, 0.0f);

    }

}
