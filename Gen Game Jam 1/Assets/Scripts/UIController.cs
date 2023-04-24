using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI gameOvertext;
    [SerializeField]
    GameObject titletext;
    [SerializeField]
    Button startBtn;    
    [SerializeField]
    Button restartBtn;
    [SerializeField]
    TextMeshProUGUI instructionsText;    
    [SerializeField]
    TextMeshProUGUI switchPosPUinstructionsText;    
    [SerializeField]
    TextMeshProUGUI doubleForcePUinstructionsText;
    
    WaitForSeconds waitFor;
    
    public int secsToWait;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pasando");
        instructionsText.gameObject.SetActive(false);
        doubleForcePUinstructionsText.gameObject.SetActive(false);
        switchPosPUinstructionsText.gameObject.SetActive(false);
        restartBtn.onClick.AddListener(RestartGame);
        restartBtn.gameObject.SetActive(false);
        startBtn.onClick.AddListener(FirstStart);
        startBtn.gameObject.SetActive(true);
        gameOvertext.gameObject.SetActive(false);
        titletext.gameObject.SetActive(true);
        Debug.Log("LLogre");
        waitFor = new WaitForSeconds(3);


    }

    public IEnumerator StartGame()
    {
        instructionsText.gameObject.SetActive(true);
        yield return waitFor;
        instructionsText.gameObject.SetActive(false);

    }    
    public IEnumerator SwitchPosPU()
    {
        switchPosPUinstructionsText.gameObject.SetActive(true);
        yield return waitFor;
        switchPosPUinstructionsText.gameObject.SetActive(false);

    }    
    public IEnumerator DoubleForcePU()
    {
        doubleForcePUinstructionsText.gameObject.SetActive(true);
        yield return waitFor;
        doubleForcePUinstructionsText.gameObject.SetActive(false);

    }
    void FirstStart()
    {
        GameManager.Instance.gameState = GameState.play;
        StartCoroutine(StartGame());
        startBtn.gameObject.SetActive(false);
        titletext.gameObject.SetActive(false);
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState == GameState.gameOver)
        {
            gameOvertext.text = "Game over!, the winner is " + GameManager.Instance.winner;
            gameOvertext.gameObject.SetActive(true);
            restartBtn.gameObject.SetActive(true);
        }
    }
}
