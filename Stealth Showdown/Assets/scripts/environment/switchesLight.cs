using UnityEngine;
using UnityEngine.Rendering.Universal;

public class switchesLight : MonoBehaviour
{
    [SerializeField]private GameObject _lamp;
    [SerializeField]private GameObject _player;
    private Light2D _light2d;
    private Transform _distanseToPlayer;
    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _distanseToPlayer = _player.GetComponent<Transform>();
        _light2d = _lamp.GetComponentInChildren<Light2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        DistanceToPlayer();
    }

    private void DistanceToPlayer()
    {
        float dist = Vector2.Distance(_distanseToPlayer.position, transform.position);
        if (dist <= 1)
        {
            _spriteRenderer.color = Color.green;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SwitchLamp();
            }
        }
        else {
            _spriteRenderer.color = Color.red;
        }
    }

    private void SwitchLamp()
    {
            _light2d.enabled = !_light2d.enabled;
    }
}
