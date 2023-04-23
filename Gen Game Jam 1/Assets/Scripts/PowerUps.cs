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
    private float timePower = 8;
    // Start is called before the first frame update
    void Start()
    {
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
            aplyPowerUp(player1,player2);
            power.idlePower();
            contPlayerA = 0;
            contPlayerB = 0;
            //Destroy(power.A);
        }
        if(contPlayerB == power.life)
        {
            Debug.Log("Gano B");
            aplyPowerUp(player2,player1);
            power.idlePower();
            contPlayerB = 0;
            contPlayerA = 0;
            //Destroy(power.B);
        }
    }
    private IEnumerator colliderOn(GameObject player)
    {
        yield return new WaitForSeconds(2);
        player.GetComponent<Collider>().enabled = true;
    }
    public void aplyPowerUp(GameObject playerWin,GameObject playerLose)
    {
        if(power.actualPower == "Change")
        {
            Debug.Log("Cambio");
            Debug.Log(playerWin.transform.position);
            Debug.Log(playerLose.transform.position);

            Vector3 tmpPosition = playerWin.transform.position;
            //playerWin.GetComponent<Collider>().enabled = false;
            //StartCoroutine(colliderOn(playerWin));
            playerWin.transform.position = playerLose.transform.position;
            playerLose.transform.position = tmpPosition;
            Debug.Log(playerWin.transform.position);
            Debug.Log(playerLose.transform.position);
        }
        else if(power.actualPower == "timeStop")
        {
            Debug.Log("time stop");
            StartCoroutine(stopLoser(playerLose));
        }
        else if(power.actualPower == "PushUp")
        {
            Debug.Log("A volar");
            playerWin.GetComponent<PlayerController>().PushPower(2);
        }
    }
    public void updatePowerTime()
    {
        time+= Time.deltaTime;
        if(time>timePower)
        {
            time = 0;
            contPlayerB = 0;
            contPlayerA = 0;
            power.changePower();
        }
    }

    public IEnumerator stopLoser(GameObject player)
    {
        float tmp = player.GetComponent<PlayerController>().pushForce;
        player.GetComponent<PlayerController>().pushForce = 0;
        yield return 3;
        player.GetComponent<PlayerController>().pushForce = tmp;
    }    
}
