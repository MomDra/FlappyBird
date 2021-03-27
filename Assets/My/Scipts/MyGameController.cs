using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyGameController : MonoBehaviour
{
    public static MyGameController instance;

    [SerializeField]
    GameObject gameOverText;
    [SerializeField]
    Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    int score = 0;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdDie()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}