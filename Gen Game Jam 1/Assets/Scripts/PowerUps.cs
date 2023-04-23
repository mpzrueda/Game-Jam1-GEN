using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public int contPlayerA = 0;
    public int contPlayerB = 0;

    public Power power;

    public GameObject player1;
    
    public GameObject player2;

    private float time = 0;
    private float timePower = 5;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciando power");
        power.changePower();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState == GameState.gameOver) return;
        updatePowerTime();
        checkLife();
        if(Input.GetKeyDown(KeyCode.A))
        {
            contPlayerA+=1;
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            contPlayerB+=1;
        }
    }

    public void checkLife()
    {        
        if(contPlayerA == power.life)
        {
            Debug.Log("Gano A");
            power.idlePower();
            contPlayerA = 0;
            aplyPowerUp(player1,player2);
            //Destroy(power.A);
        }
        if(contPlayerB == power.life)
        {
            Debug.Log("Gano B");
            power.idlePower();
            contPlayerB = 0;
            aplyPowerUp(player2,player1);
            //Destroy(power.B);
        }
    }

    public void aplyPowerUp(GameObject playerWin,GameObject playerLose)
    {
        if(power.actualPower == "Change")
        {
            Debug.Log("Entre a verificar");
            if(playerWin.GetComponent<PlayerController>().IsWinning == false)
            {
                Debug.Log("Cambio");
                Transform tmpPosition = player1.transform;
                player1.transform.position = player2.transform.position;
                player2.transform.position = tmpPosition.position; 
            }
        }
        if(power.actualPower == "PushUp")
        {
            playerWin.GetComponent<PlayerController>().PushPower(-2);
        }
    }
    public void updatePowerTime()
    {
        //Debug.Log(time);
        time+= Time.deltaTime;
        if(time>timePower)
        {
            time = 0;
            power.changePower();
        }
    }
}
