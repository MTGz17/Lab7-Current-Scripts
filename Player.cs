using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 3.0f; //Movement speed, faster than enemy
    public int health = 3; //Health, has room to take damage
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public Camera cam;

    void Start()
    {

    }

    void Update()
    {
       float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //Horizontal input
       float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime; //Vertical input
       transform.position += new Vector3(moveX, 0, moveZ); //Movement

        //Camera looking at the cursdor
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        float t = cam.transform.position.y / (cam.transform.position.y - point.y);
        Vector3 finalPoint = new Vector3(t * (point.x - cam.transform.position.x) + cam.transform.position.x, 1, t * (point.z - cam.transform.position.z) + cam.transform.position.z);
        transform.LookAt(finalPoint, Vector3.up);


        //Health UI
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

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