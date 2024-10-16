using UnityEngine;

// To move camera, disable TrackedPoseDriver in the camera becuase it will update the camera position to the origin.
public class CameraMovement : MonoBehaviour
{
    public float TranslateSpeed = 10f;
    public float rotateSpeed = 100f;


    // Update is called once per frame
    void Update()
    {
        // Translate Camera
        // More frames are processed per second on higher performance hardware.
        float horizontal = Input.GetAxis("Horizontal") * TranslateSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * TranslateSpeed * Time.deltaTime;
        float scroll = Input.GetAxis("Mouse ScrollWheel")  * TranslateSpeed * Time.deltaTime;

        transform.Translate(horizontal, vertical, scroll);  // y is the asix for the camera zoom

        // Rotate Camera using WASD
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);  // Rotate around the y-axis in anti-clockwise
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);  // Rotate around the y-axis in clockwise
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-rotateSpeed * Time.deltaTime, 0, 0);  // Rotate around the x-axis in anti-clockwi
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);  // Rotate around the x-axis in clockwise
        }
    }
}   
