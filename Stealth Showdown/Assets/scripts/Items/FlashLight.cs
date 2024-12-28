using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    private Light2D _light2d;
    private PolygonCollider2D _polygonCollider;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _light2d = _light.GetComponent<Light2D>();
        _polygonCollider = _light2d.GetComponent<PolygonCollider2D>();
    }
    private void Start()
    {
        GameInput.Instance.OnClickMouse += FlashOnOff;
        _light.GetComponent<Light2D>().intensity = 12.5f; // Можно сделать обычный и мощный фонарики и менять intensity и outer
    }

    private void Update()
    {
        if (_spriteRenderer.enabled == false) {
            _polygonCollider.enabled = false;
            _light2d.enabled = false;
        }
    }

    private void FlashOnOff(object sender, System.EventArgs e)
    { 
        if(_spriteRenderer.enabled == true)
        {
            _polygonCollider.enabled = !_polygonCollider.enabled;
            _light2d.enabled = !_light2d.enabled;
        }
    } 
}
