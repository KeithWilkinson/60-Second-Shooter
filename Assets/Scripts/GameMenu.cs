using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameMenu : MonoBehaviour
{
    public static bool isGameOver = false;
    private static int _playerScore = 0;
    public TMP_Text scoreText;
    public Image[] LifeGraphics;
    private Image[] EndGameText;

    [SerializeField] private GameObject _gameOverTextsContainer;
    public TMP_Text gameOverText;

    public static bool _hasWon;
   
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        _gameOverTextsContainer.SetActive(false);
        _playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = _playerScore.ToString();
        if(isGameOver == true && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (isGameOver == true && Input.GetKeyDown(KeyCode.Backspace))
        {
            ExitToMenu();
        }
        if (isGameOver == true)
        {
           if(_hasWon == true)
           {
                gameOverText.color = new Color32(34, 255, 0, 255);
                _gameOverTextsContainer.SetActive(true);
                gameOverText.text = "You win";
           }
           else if(_hasWon == false)
           {
                gameOverText.color = new Color32(255, 0, 0, 255);
                _gameOverTextsContainer.SetActive(true);
                gameOverText.text = "Game over";
               
           }

        }
    }

    // Reloads current scene
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Takes player back to main menu
    void ExitToMenu()
    {
        MainMenu.previousPlayScore = _playerScore;

        SceneManager.LoadScene("MenuScene");
    }

    // Increase player score
    public static void IncreaseScore(int pointsToAdd)
    {
        _playerScore += pointsToAdd;
    }
}
