using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Fire(float speed, Vector3 direction) 
    {
        _rb.velocity = direction * speed;
    }

    void OnTriggerEnter(Collider other) //Initiates damage NOTE: Most have rigid body enabled on 'Player' & must have 'Enemy' as trigger
    {
        if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3);
    }
}
