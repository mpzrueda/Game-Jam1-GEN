using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

    string[] powersNames = {"Change", "PushUp", "timeStop"};

    public int life;
    public int changePowerLife = 10;
    public int duplicatePowerLife = 5;
    public int timeStopPowerLife = 5;

    public GameObject A;
    public GameObject B;

    public void changePower()
    {
        Debug.Log("Cambiemos de poder");
        int RandomNumber = Random.Range(0,3);
        
        if(powersNames[RandomNumber] == "Change")
        {
            life = changePowerLife;
        }
        if(powersNames[RandomNumber] == "PushUp")
        {
            life = duplicatePowerLife;
        }
        if(powersNames[RandomNumber] == "timeStop")
        {
            life = timeStopPowerLife;
        }


        Debug.Log("Toco el poder: " + powersNames[RandomNumber]);
    }

}
