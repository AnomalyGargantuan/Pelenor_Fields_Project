﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    private int lives = 100;
    private int money = 100;
    private int shield = 0;

    public Text moneyText;
    public Text livesText;
    public Text shieldText;

    protected ScoreManager() {}

    public int Money
    {
        get
        {
            return money;
        }
    }

    public int Shield
    {
        get
        {
            return shield;
        }

        set
        {
            shield = value;
        }
    }

    
    public void LoseLife(int l=1)
    {
        lives -= l;

        if(lives <= 0)
        {
            GameOver();
        }
    }
    
    public void GameOver()
    {
        Debug.Log("Game Over");

        // TODO: Send the player to a game-over screen instead!
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        // FIXME: This Doesn't actually need to update the text every frame.
        moneyText.text = "Money: " + money;
        livesText.text = "Lives: " + lives;
        shieldText.text = "Shield: " + shield;

    }

    // Use for all money transactions
    public bool addMoney(int money)
    {
        bool transactionStatus = false;

        // Tries to add the money. if it goes negative, denies the transaction
        if ((this.money + money) < 0)
        {
            Debug.Log("Not enough money");
            return transactionStatus;
        }

        this.money += money;
        transactionStatus = true;
        return transactionStatus;
    }
}
