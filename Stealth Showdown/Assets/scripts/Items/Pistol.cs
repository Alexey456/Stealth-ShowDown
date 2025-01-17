using System.Collections;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _speedBullet = 5f;
    private GameObject newBullet;
    private float _timerMaxMoveBullet = 5f;
    private float _timerMoveBullet;
    private Transform _posThis;
    private Transform transformNewBul;
    private SpriteRenderer _spriteRenderer;
    private float timer = 0f;
    private float maxTimer = 2f;

    private bool _flagForCreateNewBullet;

    private void Awake()
    {
        _posThis = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        GameInput.Instance.OnClickMouse += CreateBullet_OnClickMouse;
        _flagForCreateNewBullet = true;
    }

    private void Update()
    {
        if (newBullet != null)
            MoveBullet();

        if (_flagForCreateNewBullet == false)
        {
            CheckForCreation();
        }
    }

    private void CheckForCreation()
    {

        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            _flagForCreateNewBullet = true;
            timer = 0f;
        }

    }

    private void CreateBullet_OnClickMouse(object sender, System.EventArgs e)
    {
        if (_spriteRenderer.enabled != false && _flagForCreateNewBullet == true)
            CreateBullet();
    }

    private void MoveBullet()
    {
        _timerMoveBullet += Time.deltaTime;
        if (_timerMoveBullet > _timerMaxMoveBullet)
        {
            DestroyBullet();
            _timerMoveBullet = 0f;
        }
        transformNewBul.Translate(new Vector2(1f, 0f) * _speedBullet * Time.deltaTime, transformNewBul); // полет пули в том направлении, в котором она была созданна(transformNewBul)
    }

    public void DestroyBullet()
    {
        if (newBullet != null)
            Destroy(newBullet);
    }

    private void CreateBullet()
    {
        if (newBullet == null)
        {
            _flagForCreateNewBullet = false;
            newBullet = Instantiate(_bullet, _posThis.position, _posThis.rotation) as GameObject; // создание пули в направлении поворота пистолета и в его позиции
            transformNewBul = newBullet.GetComponent<Transform>(); // получаем трансформ только что созданной пули
        }
    }
}
