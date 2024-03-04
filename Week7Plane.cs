using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week7Plane : MonoBehaviour
{

    public float length, height;
    [SerializeField] private GameObject prefab;

    void Start()
    {

        CreateGround();
        InvokeRepeating("SpawnObject", 1, 1.5f);
    }

    void CreateGround()
    {
        Vector3 worldOrigin = new Vector3(0, 0, 0);
        GameObject plane  = GameObject.CreatePrimitive(PrimitiveType.Plane);

        plane.transform.localScale = new Vector3 (length, 1, height);
        var planeRenderer = plane.GetComponent<Renderer>();
        planeRenderer.material.SetColor("_Color", Color.black);

    }

    public void SpawnObject()
    {  
        GameObject prefabGameObject = Instantiate(prefab);
        
        int generator;
        generator = Random.Range(0, 4);

        float edge;
        edge = length * 5;

        if(generator == 0)
        {
            prefabGameObject.transform.position = new Vector3(Random.Range(-25f,25f), .5f, -edge);
        }
        if(generator == 1)
        {
            prefabGameObject.transform.position = new Vector3(Random.Range(-25f,25f), .5f, edge);
        }
        if(generator == 2)
        {
            prefabGameObject.transform.position = new Vector3(-edge, .5f, Random.Range(-25f,25f));
        }
        if(generator == 3)
        {
            prefabGameObject.transform.position = new Vector3(edge, .5f, Random.Range(-25f,25f));
        }

    }

    

    void Update()
    {
        
            
    }
}