using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{


    public GameObject buyMenu;

    public bool Shotgun;
    public bool Sniper;
    public bool Duel;
    public int Points;

    // Start is called before the first frame update
    void Start()
    {
        buyMenu.SetActive(false);
        bool Shotgun = false;
        bool Sniper = false;
        bool Duel = false;
        Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if((Points == 500) || (Points == 1000) || (Points == 1500))
        {
            Time.timeScale = 0f;
            buyMenu.SetActive(true);
        }
    }

    public void ShotgunButton()
    {
        Shotgun = true;
        Time.timeScale = 1f;
        buyMenu.SetActive(false);
    }

     public void SniperButton()
    {
        Sniper = true;
        Time.timeScale = 1f;
        buyMenu.SetActive(false);
    }

    public void DuelButton()
    {
        Duel = true;
        Time.timeScale = 1f;
        buyMenu.SetActive(false);
    }
}
