using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _projectileSpeed = 10f;
    private float _screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        _screenHeight = Camera.main.orthographicSize * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, _projectileSpeed * Time.deltaTime, 0);

        // Checks if projectile has left game screen
        if(this.gameObject.transform.position.y > _screenHeight)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision with enemy
        if(collision.gameObject.tag == "Enemy")
        {
            var collidedEnemy = collision.GetComponent<Enemy>();
            GameMenu.IncreaseScore(100);
            collidedEnemy.Despawn();
            Destroy(this.gameObject);
        }
    }

    
}
