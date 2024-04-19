using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMenu : MonoBehaviour
{

    public GameObject buyMenu;

    Button shotgunButton;
    Button sniperButton;
    Button duelButton;

    public int Points;

    //!!Calls player script !!
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        buyMenu.SetActive(false);
        player = FindObjectOfType<Player>(); //!! Finds Player !!
    }

    // Update is called once per frame
    void Update()
    {
        Points = ScoreScript.scoreValue;
        if((Points == 500) || (Points == 1000) || (Points == 1500))
        {
            Time.timeScale = 0f;
            buyMenu.SetActive(true);
            UpdateButtonStates();
        }
    }

    void UpdateButtonStates()
    {
        shotgunButton.gameObject.SetActive(!player.Shotgun);
        sniperButton.gameObject.SetActive(!player.Sniper);
        duelButton.gameObject.SetActive(!player.Duel);
    }

    public void ShotgunButton()
    {
        player.Shotgun = true;
        Time.timeScale = 1f;
        buyMenu.SetActive(false);
    }

     public void SniperButton()
    {
        player.Sniper = true;
        Time.timeScale = 1f;
        buyMenu.SetActive(false);
    }

    public void DuelButton()
    {
        player.Duel = true;
        Time.timeScale = 1f;
        buyMenu.SetActive(false);
    }
}