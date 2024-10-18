using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;
//    public float slideSpeed = 10f;
    public float slideLowerLimit = 0.0f;
    public float slideUpperLimit = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.R))
       {
//            slider.value = slideSpeed * Time.deltaTime;
            slider.value += 0.1f;
//            text.text = slider.value.ToString();
       }
       if(Input.GetKeyDown(KeyCode.L))
       {
            slider.value -= 0.1f;
 //           text.text = slider.value.ToString();
       }
    }
}
