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
    [SerializeField]
    Collider deadEnd;
    [SerializeField]
    Collider enemyDeadEnd;
    public bool isDead;
    ParticleSystem strenghtparticleSystem;


    Rigidbody rbPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        isDead = false;
        strenghtparticleSystem = GetComponentInChildren<ParticleSystem>();
        clickCounter = 0;
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.gameState == GameState.gameOver) return;
        rbPlayer.AddForce(Vector3.right * dir, ForceMode.Impulse);
        inicialPos = GameManager.Instance.center.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState == GameState.gameOver) return;

        Inputs();
        if(transform.position.x < inicialPos.x * dir )
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
            strenghtparticleSystem.Play();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == deadEnd.gameObject)
        {
            rbPlayer.AddForce(Vector3.right * 7 * -dir, ForceMode.Impulse);
            strenghtparticleSystem.Stop();
            isDead = true;

        }
        else if (other.gameObject == enemyDeadEnd.gameObject)
        {
            GameManager.Instance.winner = this.gameObject;
            rbPlayer.constraints = RigidbodyConstraints.FreezePositionX;
            strenghtparticleSystem.Stop();

            rbPlayer.AddTorque(Vector3.up * 10);
        }
    }
}

