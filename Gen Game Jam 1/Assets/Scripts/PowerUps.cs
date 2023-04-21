using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public int contPlayerA = 0;
    public int contPlayerB = 0;

    public Power power;

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
            //Destroy(power.A);
        }
        if(contPlayerB == power.life)
        {
            Debug.Log("Gano B");
            power.idlePower();
            contPlayerB = 0;
            //Destroy(power.B);
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
