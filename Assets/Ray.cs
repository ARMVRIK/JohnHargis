using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    [SerializeField] private float rayLength = 100f; 
    [SerializeField] private Camera cam;

    private Ray ray;
    void Start()
    {
        
    }

    void Update()
    {
        UnityEngine.Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            Debug.Log("Луч попал в объект: " + hit.collider.name);
        }

        Debug.DrawRay(ray.origin, ray.direction*rayLength);
    }
}
