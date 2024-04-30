using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week6 : MonoBehaviour
{

    public int sizeOfForest;
    public int stonesRequired;

    void Start()
    {
        CreateGround();
        CreateRandomForest();
        CreatePyramid();
    }

    void CreateGround()
    {
        Vector3 worldOrigin = new Vector3(0, 0, 0);
        GameObject plane  = GameObject.CreatePrimitive(PrimitiveType.Plane);

        plane.transform.localScale = new Vector3 (5, 1, 5);
        var planeRenderer = plane.GetComponent<Renderer>();
        planeRenderer.material.SetColor("_Color", Color.blue);

    }

    void CreateRandomForest()
    {
    for (int i = 0; i < (sizeOfForest); i++)
        {

        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = new Vector3(Random.Range(-10f,1f), 1, Random.Range(-5f,6f));

        var cylinderRenderer = cylinder.GetComponent<Renderer>();
        cylinderRenderer.material.SetColor("_Color", Color.green);
        
        }
    }

    void CreatePyramid()
    {  
        GameObject topcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        topcube.transform.position = new Vector3(10, stonesRequired-.5f, 0); 

        for(int height = 0; height < (stonesRequired - 1); height++)
        {
            int length = (stonesRequired - 1) - height;

            Color32 randomColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);

            for (int x = -length; x <= length; x++)
             {
                for (int z = -length; z <= length; z++)
                {
                    if (Mathf.Abs(x) == length || Mathf.Abs(z) == length)
                    {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(x+10, height+.5f, z); 

                    var cubeRenderer = cube.GetComponent<Renderer>();
                    cubeRenderer.material.SetColor("_Color", randomColor);
                    }
                }
             }
        } 
    }
}