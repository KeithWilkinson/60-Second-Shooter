using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _moveSpeed = 5f;
    public GameObject Projectile;
    private static int _playerHealth = 3;
    private static bool _isAlive = true;
    private static GameObject _gameMenu;

    private float _axisInput;
    [SerializeField] private GameObject _firePos;
    private AudioManager _audioManager;

    // Start is called before the first frame update
    void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _playerHealth = 3;
        _gameMenu = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMenu.isGameOver == false)
        {
            // Input
            float horizontalInput = Input.GetAxis("Horizontal");

            _axisInput = horizontalInput;

            // Movement
            transform.position = transform.position + new Vector3(horizontalInput * _moveSpeed * Time.deltaTime, 0, 0);

            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
    }

    // Fire projectile
    void Fire()
    {
        _audioManager.PlayShipFireSound();
        Instantiate(Projectile, _firePos.transform.position, Quaternion.identity);
    }

    // Damage player
    public static void DamagePlayer()
    {
        _playerHealth--;
        if(GameMenu.isGameOver == false)
        {
            _gameMenu.GetComponent<GameMenu>().LifeGraphics[_playerHealth].enabled = false;
        }
        // Player has died / Game over
        if(_playerHealth <= 0)
        {
            _isAlive = false;
            GameMenu.isGameOver = true;
            GameMenu._hasWon = false;
        }
    }

    public static bool isAlive
    {
        get { return _isAlive; }
        set { _isAlive = value; }
    }

}
