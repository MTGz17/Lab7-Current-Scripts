using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 20; //Damage variable
    public float speed = 2f; //Enemy movement speed slower than player
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Finds the player
    }

    void Update() //Chases the player
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
    
    void OnTriggerEnter(Collider other) //Initiates damage NOTE: Most have rigid body enabled on 'Player' & most have 'Enemy' as trigger
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player playerScript = other.gameObject.GetComponent<Player>();
            playerScript.Damage(damage);
        }
    }
}
