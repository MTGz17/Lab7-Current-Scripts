using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f; //Movement speed, faster than enemy
    public int health = 100; //Health, has room to take damage

    void Update()
    {
       float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //Horizontal input
       float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime; //Vertical input
       transform.position += new Vector3(moveX, 0, moveZ); //Movement
    }
    
    public void Damage(int damage) //Damage method by subtracting damage from health
    {
        health -= damage;
        Debug.Log("Damage Taken: " + damage + ". Player Health: " + health);
        if (health <= 0) 
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        Application.Quit(); //Only works in built version of game
    }
}