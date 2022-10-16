using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private float _scrollSpeed = 5f;
    private Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _scrollSpeed * Time.deltaTime);
        if(transform.position.y < -10.21)
        {
            transform.position = _startPosition;
        }
    }
}
