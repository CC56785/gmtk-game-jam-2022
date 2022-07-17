﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public event EventHandler EndTurn;
    private static GameManager instance;

    public static Action<int, int> OnTradedValue;

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void EndTurnButton()
    {
        if (EndTurn != null) EndTurn(this, EventArgs.Empty);
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void TradeAttackValue()
    {
        PlayerScript.GetInstance().FirstDicePoint++;
        PlayerScript.GetInstance().SecondDicePoint--;
        Debug.Log("Attack: " + PlayerScript.GetInstance().FirstDicePoint);
        Debug.Log("Range: " + PlayerScript.GetInstance().SecondDicePoint);
        OnTradedValue?.Invoke(PlayerScript.GetInstance().FirstDicePoint, PlayerScript.GetInstance().SecondDicePoint);
    }

    public void TradeRangeValue()
    {
        PlayerScript.GetInstance().FirstDicePoint--;
        PlayerScript.GetInstance().SecondDicePoint++;
        Debug.Log("Attack: " + PlayerScript.GetInstance().FirstDicePoint);
        Debug.Log("Range: " + PlayerScript.GetInstance().SecondDicePoint);
        OnTradedValue?.Invoke(PlayerScript.GetInstance().FirstDicePoint, PlayerScript.GetInstance().SecondDicePoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
