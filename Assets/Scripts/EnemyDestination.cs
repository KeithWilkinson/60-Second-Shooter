using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestination : MonoBehaviour
{
    public Vector2 currentPosition;
   public Vector2[] _possiblePositions;
   public bool changePos = false;

    public static int WhichPosition;
    public static int random;
    static bool flag = true;

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
    
    }

    private static Vector2 _newPosition;
    public void ChangeObjPos(int pos)
    {
         _newPosition = _possiblePositions[pos];
         transform.position = _newPosition;
    }

    //private int lastNumber = -1;
    //int PickNewLocation(int min, int max)
    //{
    //    int rand = Random.Range(min, max);
    //    while (rand == lastNumber)
    //    {
    //        rand = Random.Range(min, max);
    //    }
    //    lastNumber = rand;
    //    return rand;
    //}

    //void Randomise()
    //{
    //    if(flag == true)
    //    {
    //        random = Random.Range(0, 3);
    //        flag = false;
    //    }
       
    //}
    
}
