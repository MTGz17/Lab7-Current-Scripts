using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week7Plane : MonoBehaviour
{

    public float length, height;


    void Start()
    {

        CreateGround();
        
    }

    void CreateGround()
    {
        Vector3 worldOrigin = new Vector3(0, 0, 0);
        GameObject plane  = GameObject.CreatePrimitive(PrimitiveType.Plane);

        plane.transform.localScale = new Vector3 (length, 1, height);
        var planeRenderer = plane.GetComponent<Renderer>();
        planeRenderer.material.SetColor("_Color", Color.black);

    }

    

    void Update()
    {
        
            
    }
}