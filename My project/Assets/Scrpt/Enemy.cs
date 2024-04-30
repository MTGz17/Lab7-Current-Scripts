using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage; //Damage variable
    public float speed; //Enemy movement speed slower than player
    public int enemyHealth;
    public int points;
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
    
    void OnTriggerEnter(Collider other) //Initiates damage NOTE: Most have rigid body enabled on 'Player' & must have 'Enemy' as trigger
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player playerScript = other.gameObject.GetComponent<Player>();
            playerScript.Damage(damage);

            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            enemyHealth = enemyHealth - 1;
            
            if(enemyHealth == 0)
            {
                ScoreScript.scoreValue += points;
                Destroy(gameObject);
            }
        }
    }
}