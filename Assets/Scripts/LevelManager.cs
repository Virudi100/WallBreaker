using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int ballLeft = 1;
    [SerializeField] private GameObject LoseCanvas;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text ballLeftText;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private int bricksToBreak = 0;
    [HideInInspector] public int bricksCurrentlyBreak = 0;
    public MyScriptableObject Datas;
    private GameObject player;


    private void Start()
    {
        Resume();
        LoseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        scoreText.text = "Score: " + Datas.score ;
        ballLeftText.text = "Ball Left: " + ballLeft;

        if (bricksCurrentlyBreak == bricksToBreak )
        {
            Pause();
            winCanvas.SetActive(true);

        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Datas.index++;
            if (Datas.index < Datas.sceneList.Length)
            {
                SceneManager.LoadScene(Datas.sceneList[Datas.index]);
            }
            else SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ball"))
        {
            Destroy(other.gameObject);
            ballLeft--;
            player.GetComponent<Player>().isLaunch = false;

        }

        if (ballLeft == 0)
        {
            LoseCanvas.SetActive(true);
            Pause();
        }

        if(ballLeft > 0)
        {
            player.GetComponent<Player>().SpawnBall();
        }
       
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void Resume()
    {
        Time.timeScale = 1;
    }
}
