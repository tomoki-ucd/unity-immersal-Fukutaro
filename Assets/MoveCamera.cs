using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float translate_speed = 10f;
    public float rotate_speed = 100f;

    // Update is called once per frame
    void Update()
    {
        // Translate Camera
        float horizontal_move = Input.GetAxis("Horizontal") * translate_speed * Time.deltaTime;
        Debug.Log($"horizontal: {Input.GetAxis("Horizontal")}");
        Debug.Log($"horizontal_move: {horizontal_move}");

        float vertical_move = Input.GetAxis("Vertical")  * translate_speed * Time.deltaTime;
        Debug.Log($"vertical_move: {vertical_move}");

        float scroll = Input.GetAxis("Mouse ScrollWheel") * translate_speed * Time.deltaTime;           
        Debug.Log($"Mouse ScrollWhee: {scroll}");

        transform.Translate(horizontal_move, vertical_move, scroll);

        // Rotate Camera
//        transform.Rotate(0,0,90 * Time.deltaTime);
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,0,rotate_speed * Time.deltaTime);
        }
        

    }
}
