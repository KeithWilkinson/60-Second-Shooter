using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShape : MonoBehaviour
{
    public GameObject[] _enemyWavePositions;
    public EnemyDestination[] _destinations;
    public Enemy[] _enemies;
    public static int enemiesDestroyedInWave = 0;
  
    public static int numbertoPass;

    private void Awake()
    {
        //ChangePattern();
    }

    // Start is called before the first frame update
    void Start()
    {
       enemiesDestroyedInWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].MoveToStartPosition(_destinations[i].currentPosition);
            if(GameMenu.isGameOver == true)
            {
                _enemies[i].Despawn();
            }
        }

        if (CheckWave() == true)
        {
            int randomNumber = PickNewLocation(0, 5);
            numbertoPass = randomNumber;
            ChangePattern();

            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i].Respawn();
            }

            enemiesDestroyedInWave = 0;
        } 
    }

    // Check if wave has been defeated
    bool CheckWave()
    {
        if(enemiesDestroyedInWave == 20)
        {
            return true;
            
        }
        else
        {
            return false;
        }
    }

    // Changes pattern of wave
    void ChangePattern()
    {
        //Debug.Log(numbertoPass);
        foreach (EnemyDestination endest in _destinations)
        {
            endest.ChangeObjPos(numbertoPass);
            
        }
    }

    private int lastNumber = -1;
    // Generate random number between 2 given values
    public int PickNewLocation(int min, int max)
    {
        int rand = Random.Range(min, max);
        while (rand == lastNumber)
        {
            rand = Random.Range(min, max);
        }
        lastNumber = rand;
        return rand;
    }
}
