using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Control Player")]
    [SerializeField] string playerH, pushPlayer; 
    float movH; 
    [Header ("Push Force")]
    [SerializeField] float pushForce;
    [SerializeField]int dir;
    
    Rigidbody rbPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rbPlayer.AddForce(Vector3.right *dir, ForceMode.Impulse);
        Inputs();
    }
    void Inputs()
    {
        movH = Input.GetAxis(playerH);
        if(Input.GetButtonDown(pushPlayer))
        {
            Push();
        }
         
    }
    void Push()
    {
        Vector3 inputForce = new Vector3 (movH, transform.position.y, transform.position.z);  
        rbPlayer.AddForce(Vector3.right * pushForce, ForceMode.Impulse);
    }


}
