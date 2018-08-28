using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int currentTrun = 1;
    public bool isPlayerOneStating;
    public PlayerController player1, player2;


    // Use this for initialization
    void Start()
    {
        instance = this;
        int rand = Random.Range(1, 100);
        isPlayerOneStating = rand > 50;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitGame()
    {
        SceneManager.LoadScene("GameMenu");
    }
}