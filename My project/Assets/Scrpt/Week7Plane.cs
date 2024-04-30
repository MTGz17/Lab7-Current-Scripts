using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week7Plane : MonoBehaviour
{

    public float length;
    public float height;
    [SerializeField] private GameObject planePrefab;
    public GameObject[] enemyPrefabs;

    void Start()
    {
        CreateGround();
        InvokeRepeating("SpawnObject", 1, 1.5f);
    }

    void CreateGround()
    {
        Vector3 worldOrigin = new Vector3(0, 0, 0);
        GameObject plane  = Instantiate(planePrefab);

        plane.transform.localScale = new Vector3 (length+5, 1, height+2.5f);

    }

    public void SpawnObject()
    {  
        int randomEnemyGenerator;
        randomEnemyGenerator = Random.Range(0, 4);
        GameObject prefabGameObject = Instantiate(enemyPrefabs[randomEnemyGenerator]);
        
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