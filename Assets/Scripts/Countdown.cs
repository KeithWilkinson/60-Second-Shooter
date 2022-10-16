using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    private float _startingTime = 60f;
    private float _currentTime;

    private static bool _isOutOfTime;

    [SerializeField] private TMP_Text _countdownText;

    // Start is called before the first frame update
    void Start()
    {
        _currentTime = _startingTime;
 
        _isOutOfTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isOutOfTime == false && GameMenu.isGameOver == false)
        {
            _currentTime -= 1 * Time.deltaTime;
            _countdownText.text = _currentTime.ToString("0");
        }
        if(_currentTime <= 0)
        {
            _isOutOfTime = true;
            GameMenu._hasWon = true;
        }

        if (_isOutOfTime == true)
        {
            GameMenu.isGameOver = true;
        }
    }
}
