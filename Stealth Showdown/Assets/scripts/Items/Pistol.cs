using System.Collections;
using UnityEditor;
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
    private int countBul; // счетчик созданных пуль

    private void Awake()
    {
        _posThis = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        countBul = 0;
        GameInput.Instance.OnClickMouse += CreateBullet_OnClickMouse;

    }

    private void Update()
    {
        if (newBullet != null)
            MoveBullet();
    }

    private void CreateBullet_OnClickMouse(object sender, System.EventArgs e)
    {
        StartCoroutine(CreateBullet(2f));
    }

    private void MoveBullet()
    {
        _timerMoveBullet += Time.deltaTime;
        if (_timerMoveBullet > _timerMaxMoveBullet || _spriteRenderer.enabled == false)
        {
            DestroyBullet();
            _timerMoveBullet = 0f;
        }
        transformNewBul.Translate(new Vector2(1f, 0f) * _speedBullet * Time.deltaTime, transformNewBul); // полет пули в том направлении, в котором она была созданна(transformNewBul)
    }

    public void DestroyBullet()
    {
        Destroy(newBullet);
    }

    private IEnumerator CreateBullet(float wait)
    {
        if(newBullet == null)
        {
            newBullet = Instantiate(_bullet, _posThis.position, _posThis.rotation) as GameObject; // создание пули в направлении поворота пистолета и в его позиции
            transformNewBul = newBullet.GetComponent<Transform>(); // получаем трансформ только что созданной пули
            countBul++;
        }
        yield return new WaitForSeconds(wait);
    }
}
