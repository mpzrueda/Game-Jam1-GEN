using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{

    public int contPlayerA = 0;
    public int contPlayerB = 0;

    public Power power;

    public GameObject player1;
    
    public GameObject player2;

    public float time = 0;
    public float timePower = 8;

    [SerializeField]
    Slider pUSlider1;
    [SerializeField]
    Slider pUSlider2;
    // Start is called before the first frame update
    void Start()
    {
        power.changePower(pUSlider1,pUSlider2);
        pUSlider1.maxValue = power.life;
        pUSlider1.minValue = 0;
        pUSlider2.maxValue = power.life;
        pUSlider2.minValue = 0;
        pUSlider1.value = power.life;
        pUSlider2.value = power.life;
        pUSlider1.gameObject.SetActive(false);
        pUSlider2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState == GameState.gameOver) return;
        updatePowerTime();
//        pUSlider1.gameObject.SetActive(true);
  //      pUSlider2.gameObject.SetActive(true);
        checkLife();
        if(Input.GetKeyDown(KeyCode.A))
        {
            contPlayerA+=1;
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            contPlayerB+=1;
        }
        pUSlider1.value = contPlayerA;
        pUSlider2.value = contPlayerB;
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

    public void aplyPowerUp(GameObject playerWin,GameObject playerLose)
    {
        if(power.actualPower == "Change")
        {
            Vector3 tmpPosition = playerWin.transform.position;
            playerWin.transform.position = playerLose.transform.position;
            playerLose.transform.position = tmpPosition;
            playerWin.GetComponent<PlayerController>().dir*=-1;
            playerLose.GetComponent<PlayerController>().dir*=-1;
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
            power.changePower(pUSlider1, pUSlider2);
       //     pUSlider1.gameObject.SetActive(false);
         //   pUSlider2.gameObject.SetActive(false);
        }
    }

    public IEnumerator stopLoser(GameObject player)
    {
        float tmp = player.GetComponent<PlayerController>().pushForce;
        player.GetComponent<PlayerController>().pushForce = 1000;
        yield return 3;
        player.GetComponent<PlayerController>().pushForce = tmp;
    }    
}
