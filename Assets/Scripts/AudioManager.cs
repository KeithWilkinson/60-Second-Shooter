using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _enemyDestroy;
    [SerializeField] private AudioClip _shipShoot;
    private static AudioSource _audsrc;
    private float _audsrcPitch;
    // Start is called before the first frame update
    void Start()
    {
        _audsrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Play ship fire sound and randomise pitch
    public void PlayShipFireSound()
    {
        var _pitch = Random.Range((float)0.5, (float)1.5);
        _audsrcPitch = _pitch;
        _audsrc.pitch = _audsrcPitch;
        _audsrc.PlayOneShot(_shipShoot);
    }

    // Play enemy destroy sound
    public void PlayEnemyDestroySound()
    {
        _audsrc.PlayOneShot(_enemyDestroy);
    }
}
