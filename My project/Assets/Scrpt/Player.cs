using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 3.0f; //Movement speed, faster than enemy
    public int health = 3; //Health, has room to take damage
    public int maxHealth;
    public AudioClip blaster;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public Camera cam;

    [SerializeField] private float projectileSpeed;
    [SerializeField] private Projectile projectilePrefab;

    AudioSource audioSource;

    public int Points;
    public bool Shotgun;
    public bool Duel;

    public Week7Plane script;

    public float cooldown;
    float lastShot;

    public Transform forward;
    public Transform left;
    public Transform right;
    public Transform backward;

    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        Shotgun = false;
        Duel = false;
    }

    void Update()
    {
       float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //Horizontal input
       float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime; //Vertical input
       transform.position += new Vector3(moveX, 0, moveZ); //Movement

       if(transform.position.x >= ((script.length*1.5f)*2))
       {
            transform.position = new Vector3(((script.length*1.5f)*2), 1, transform.position.z);
       }
       if(transform.position.x <= -((script.length*1.5f)*2))
       {
            transform.position = new Vector3(-((script.length*1.5f)*2), 1, transform.position.z);
       }
       if(transform.position.z >= ((script.height*1.5f)*2))
       {
            transform.position = new Vector3(transform.position.x, 1, ((script.height*1.5f)*2));
       }
       if(transform.position.z <= -((script.height*1.5f)*2))
       {
            transform.position = new Vector3(transform.position.x, 1, -((script.height*1.5f)*2));
       }

        //Camera looking at the cursor
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        float t = cam.transform.position.y / (cam.transform.position.y - point.y);
        Vector3 finalPoint = new Vector3(t * (point.x - cam.transform.position.x) + cam.transform.position.x, transform.position.y, t * (point.z - cam.transform.position.z) + cam.transform.position.z);
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

        if(!PauseMenu.isPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
               if(Time.time-lastShot<cooldown)
                {
                    return;
                }
                lastShot = Time.time;
               var rotation = transform.rotation;
               var projectile = Instantiate(projectilePrefab, forward.position, rotation);
               projectile.Fire(projectileSpeed, transform.forward);
               PlaySound(blaster);
               if(Duel == true)
               {
                var projectileback = Instantiate(projectilePrefab, backward.position, rotation);
                projectileback.Fire(projectileSpeed, -(transform.forward));
               }
               if(Shotgun == true)
               {
                var projectileleft = Instantiate(projectilePrefab, left.position, rotation);
                projectileleft.Fire(projectileSpeed, transform.forward);
                var projectileright = Instantiate(projectilePrefab, right.position, rotation);
                projectileright.Fire(projectileSpeed, transform.forward);
               }
            }
        }

        Points = ScoreScript.scoreValue;
        if((Points >= 1000))
            {
                Duel = true;
            }
        if((Points >= 1500))
            {
                Shotgun = true;
            }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
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
        SceneManager.LoadScene("EndGame");
    }
}