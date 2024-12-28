using System.Collections;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class metallDetected : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    private float _timerMaxSound = 3f;
    private float _timerCurrentSound;
    private int countTriggersWithPlayer = 0;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheckCountAndTimer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            countTriggersWithPlayer++;
            if (countTriggersWithPlayer == 1) {
                _audioSource.Play();
            }
        }
    }

    private void CheckCountAndTimer()
    {
        if (countTriggersWithPlayer > 0)
        {
            // вкл анимацию
            _timerCurrentSound += Time.deltaTime;
            if (_timerCurrentSound >= _timerMaxSound)
            {
                _audioSource.Stop();
                _timerCurrentSound = 0;
                countTriggersWithPlayer = 0;
            }
        }
    }
}
