using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text highScoreText;
    private static int _highScore = 0;
    public static int previousPlayScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(previousPlayScore);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            PlayGame();
        }
        if(previousPlayScore > _highScore)
        {
            _highScore = previousPlayScore;
        }
        highScoreText.text = _highScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

  
}
