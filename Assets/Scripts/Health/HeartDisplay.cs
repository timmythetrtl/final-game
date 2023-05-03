using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject player;
    PlayerStats playerStats;

    bool check;

    void Start()
    {
        numOfHearts = 0;
        check = false;
        StartCoroutine(WaitForPlayer());
    }

    IEnumerator WaitForPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        while (playerObj == null)
        {
            yield return null;
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }

        player = playerObj;
        playerStats = player.GetComponent<PlayerStats>();
        check = true;
    }

    void Update()
    {
        if(check){
            numOfHearts = playerStats.characterData.MaxHealth;

            for (int i = 0; i < hearts.Length; i++)
            {

                if (i < playerStats.currentHealth)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }

                if (i < numOfHearts)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
        }
        

        
    }
}
