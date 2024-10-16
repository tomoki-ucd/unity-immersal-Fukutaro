using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;  // needed for Where()

public class ToggleGroupController : MonoBehaviour
{
    public GameObject MenuObject;   // Reference to mesh object, i.e., Fukutaro
    public ToggleGroup toggleGroup; // Reference to the ToggleGroup component

    // Start is called before the first frame update
    void Start()
    {
        if (MenuObject == null)
        {
            Debug.Log("MenuObject is not assigned in the Inspector!");
            return;
        }
        // Ensure there is a ToggleGroup assigned.
        if (toggleGroup == null)    // If there is no toggleGroup
        {
//            Debug.LogError("ToggleGroup is not assigned in the Inspector!");
            Debug.Log("ToggleGroup is not assigned in the Inspector!");
            return; // Exit Start()
        }       

        // In case you do not put Toggle objects under the toggleGroup as its child objects;
//        Toggle[] allToggles = FindObjectsOfType<Toggle>();
//        Toggle[] togglesInGroup = allToggles.Where(t => t.group == toggleGroup).ToArray();
//        Debug.Log("Number of Toggles found in group " + togglesInGroup.Length);


        // Register an even listener for each toggle in the group
        foreach ( Toggle toggle in toggleGroup.GetComponentsInChildren<Toggle>())
//        foreach ( Toggle toggle in togglesInGroup)
        {
            toggle.onValueChanged.AddListener((isOn) => OnToggleValueChanged(toggle, isOn)); // Register a Lambda (anonymous) function
            Debug.Log("toggle.onValueChanged.AddListener() done!");
        }
    }

    // Called whenever toggles is switched
    void OnToggleValueChanged(Toggle changedToggle, bool isOn)
    {
        Debug.Log("Toggle changed: " + changedToggle.name + " | New state: " + isOn);

        if (changedToggle.name == "Toggle-ON" && isOn)
        {
            Debug.Log("Toggle " + changedToggle.name + "is ON!");
            MenuObject.gameObject.SetActive(true);
        } else if(changedToggle.name == "Toggle-OFF" && isOn){
            Debug.Log("Toggle " + changedToggle.name + "is OFF!");
            MenuObject.gameObject.SetActive(false);
        }
    }
}
