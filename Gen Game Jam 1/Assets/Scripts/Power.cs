using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{

    string[] powersNames = {"Change", "PushUp", "timeStop","Idle","Idle","Idle","Idle","Idle","Idle","Idle"};

    public int life;
    public int changePowerLife = 10;
    public int duplicatePowerLife = 5;
    public int timeStopPowerLife = 5;
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
        int RandomNumber = Random.Range(0,5);
        actualPower = powersNames[RandomNumber]; 
        if(powersNames[RandomNumber] == "Change")
        {
            life = changePowerLife;
            powerSlot1.sprite = power[0];
            powerSlot2.sprite = power[0];

        }
        else if(powersNames[RandomNumber] == "PushUp")
        {
            life = duplicatePowerLife;
            powerSlot1.sprite = power[1];
            powerSlot2.sprite = power[1];
        }
        //else if(powersNames[RandomNumber] == "timeStop")
        //{
        //    life = timeStopPowerLife;
        //    powerSlot1.sprite = power[2];
        //    powerSlot2.sprite = power[2];
        //}
        else
        {
            life = timeStopPowerLife;
            powerSlot1.sprite = power[3];
            powerSlot2.sprite = power[3];
        }
        Debug.Log("Toco el poder: " + powersNames[RandomNumber]);
    }

    public void idlePower()
    {
        life = 100;
        powerSlot1.sprite = power[3];
        powerSlot2.sprite = power[3];
    }

}
