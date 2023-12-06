using System.Collections.Generic;
using UnityEngine;

public class ChristmasTree : MonoBehaviour
{
    public Camera camera;
    public List<GameObject> toys;
    private int i = 0;

    public void zero()
    {
        i = 0;
    }
    public void one()
    {
        i = 1;
    }
    public void two()
    {
        i = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse input (left mouse button)
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in screen coordinates
            Vector3 mousePosition = Input.mousePosition;

            // Cast a ray from the camera through the mouse position
            Ray ray = camera.ScreenPointToRay(mousePosition);

            // Perform the raycast and store the hit information
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                // Instantiate a specific toy from the list based on the value of i
                if (i >= 0 && i < toys.Count)
                {
                    GameObject selectedToy = toys[i];
                    Instantiate(selectedToy, hitInfo.point, Quaternion.identity);
                }
                else
                {
                    Debug.LogWarning("Invalid toy index: " + i);
                }

                Debug.Log("Hit object: " + hitInfo.collider.gameObject.name);
            }
            else
            {
                // The ray did not hit any object
                Debug.Log("Ray did not hit anything.");
            }
        }
    }
}
