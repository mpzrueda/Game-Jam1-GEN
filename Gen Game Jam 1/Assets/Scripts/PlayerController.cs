using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [Header("Control Player")]
    [SerializeField]
    string playerH, pushPlayer;
    float movH;
    [Header("Push Force")]
    [SerializeField]
    float pushForce;
    [SerializeField]
    int dir;
    public int clickCounter;
    [SerializeField]
    float addStrenght;
    Vector3 inicialPos;
    public bool IsWinning;
    public Action onDeath;
    

    Rigidbody rbPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        inicialPos = transform.position;
    }

    private void FixedUpdate()
    {
        rbPlayer.AddForce(Vector3.right * dir, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        if(transform.position.x < inicialPos.x * dir)
        {
            IsWinning = true;
            Debug.Log(this + " Is Winning");
        }
        else
        {
            IsWinning = false;
        }
        if(transform.position.y < inicialPos.y -10)
        {
            Lose();
            Debug.Log("Player was pushed out");
        }

    }
    void Inputs()
    {
        movH = Input.GetAxis(playerH);
        if (Input.GetButtonDown(pushPlayer))
        {
            clickCounter += 1;
            pushForce += addStrenght;
            Push();
        }

    }
    void Push()
    {
        Vector3 inputForce = new Vector3(movH, transform.position.y, transform.position.z);
        rbPlayer.AddForce(Vector3.right * (pushForce *dir), ForceMode.Impulse);
    }
    public void Lose()
    {
        onDeath?.Invoke();
    }

}
