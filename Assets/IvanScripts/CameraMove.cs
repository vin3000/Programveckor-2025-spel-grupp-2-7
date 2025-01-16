using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //locks the cursor to the center of the screen and hides it
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    private void Update()
    {
        //get mouse position 
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;

        //allows us to looks up and down and locks it to a 180 degree angle
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //rotate player on y axis when we move our mouse
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
