using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 _startPos;
    private Vector2 _currentPosition;
    private Vector2 _TargetPos;
    private float _moveSpeed = 5f;
    private bool _inPosition = false;
    private bool _moving = false;
    private static int _readyCounter = 0;
    private bool stopCouunt;
    [SerializeField] private GameObject _explosionEffect;
    private AudioManager _audioManager;

    // Start is called before the first frame update
    void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMenu.isGameOver == false)
        {
            float step = _moveSpeed * Time.deltaTime;
            // Move towards starting position
            if (_inPosition == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, _TargetPos, step);
            }
            // Checks if enemy is in posiiton ready to move down screen
            if (gameObject.transform.position.x == _TargetPos.x && gameObject.transform.position.y == _TargetPos.y)
            {
                stopCouunt = true;
                _inPosition = true;
                if (stopCouunt == true)
                {
                    _readyCounter++;

                    stopCouunt = false;
                }

            }
            // Move enemy down screen
            if (_moving == true)
            {
                transform.position = transform.position + new Vector3(0, -0.6f * Time.deltaTime, 0);
            }

            if (_readyCounter >= 20)
            {
                StartCoroutine(MoveEnemy(5));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy goes off screen
        if(collision.gameObject.tag == "DeathBox")
        { 
            Despawn();
            Player.DamagePlayer();
        }
        // Enemy hits player
        if(collision.gameObject.tag == "Player")
        {
            Despawn();
            Player.DamagePlayer();
        }
    }

    // Moves enemy to start position
    public void MoveToStartPosition(Vector2 enemyTargetPosition)
    {
        _TargetPos = new Vector2(enemyTargetPosition.x,enemyTargetPosition.y);
    }

    // Respawn enemy
    public void Respawn()
    {
        this.gameObject.SetActive(true);
    }

    // Destroys enemy, restes position and plays effect
    public void Despawn()
    {
        if(GameMenu.isGameOver == false)
        {
            _audioManager.PlayEnemyDestroySound();
            Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        }
        this.gameObject.SetActive(false);
        WaveShape.enemiesDestroyedInWave++;
        transform.position = _startPos;
        _inPosition = false;
        _moving = false;
    }
    public IEnumerator MoveEnemy(float duration)
    {
        yield return new WaitForSeconds(duration);
        _moving = true;
        _readyCounter = 0;
    }

    public bool inPosition
    {
        get { return _inPosition; }
        set { _inPosition = value; }
    }

}
