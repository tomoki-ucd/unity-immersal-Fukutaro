using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshFilter))] public class GetClickedPointEditor: Editor
{
    private void OnSceneGUI()
    {
        Ray ray;
        if(Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit Object: " + hit.collider.name);
                Debug.Log("Clicked Point: " + hit.point);
            }
        }
    }
}
