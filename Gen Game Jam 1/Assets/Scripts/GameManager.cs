using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    
    public PlayerController player1;
    
    public PlayerController player2;
    public UIController ui;
    public Collider center;
    public GameState gameState;
    public GameObject winner;
    public PowerUps powerUps;
    private void Awake()
    {
        if(Instance != null)
        {
            if(Instance != this)
            {
                DestroyImmediate(this);
            }
        }
        instance = this;
    }
    void Start()
    {
        gameState = GameState.start;
        player1.onDeath += GameOver;
        player2.onDeath += GameOver;
    }

    void GameOver()
    {
        gameState = GameState.gameOver;
        Debug.Log("the winner is " + winner);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum GameState
{
    start,
    play,
    gameOver
}