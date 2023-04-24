using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{

    string[] powersNames = {"Change", "PushUp", "timeStop","Idle"};

    public int life;
    public int changePowerLife = 15;
    public int duplicatePowerLife = 15;
    public int timeStopPowerLife = 15;
    public int idleTime = 10;
    public string actualPower;
    [SerializeField] Sprite[] power;
    [SerializeField] Image powerSlot1, powerSlot2;

    public GameObject A;
    public GameObject B;
    
    void Start()
    {

    }
    public void changePower()
    {
        int RandomNumber = Random.Range(0,4);
        actualPower = powersNames[RandomNumber]; 
        if(actualPower == "Change")
        {
            StartCoroutine(GameManager.Instance.ui.SwitchPosPU());
            life = changePowerLife;
            powerSlot1.sprite = power[0];
            powerSlot2.sprite = power[0];

        }
        else if(actualPower == "PushUp")
        {
            StartCoroutine(GameManager.Instance.ui.DoubleForcePU());
            life = duplicatePowerLife;
            powerSlot1.sprite = power[1];
            powerSlot2.sprite = power[1];
        }
        else if(actualPower == "timeStop")
        {
            life = timeStopPowerLife;
            powerSlot1.sprite = power[2];
            powerSlot2.sprite = power[2];
        }
        else
        {
            life = timeStopPowerLife;
            powerSlot1.sprite = power[3];
            powerSlot2.sprite = power[3];
        }
    }

    public void idlePower()
    {
        life = 100;
        powerSlot1.sprite = power[3];
        powerSlot2.sprite = power[3];
    }

}
