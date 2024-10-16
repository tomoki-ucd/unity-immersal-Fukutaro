using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugControlSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
//    private Slider slider;
    public float moveSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
//       slider = this.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.R)) 
       {
           slider.value += moveSpeed * Time.deltaTime; // deltaTime is time diff between the previous and the current frame
       }

       if(Input.GetKey(KeyCode.L))
       {
            slider.value -= moveSpeed * Time.deltaTime;
       }
    }
}
