using UnityEngine;
using System.Collections.Generic;

public class ActiveItem : MonoBehaviour
{
    [SerializeField] List<GameObject> _activeItems = new List<GameObject>(); // создаем динамический список с типом GameObject
    private Vector3 MousePos;
    private Vector3 PlayerPos;
    public static ActiveItem Instance
    {
        get; private set;
    }

    private void Start()
    {
        Instance = this;
        _activeItems.Find(x => x.CompareTag("FlashLight")).GetComponent<SpriteRenderer>().enabled = true;// находим объект в list по тегу и включаем спрайт
        _activeItems.Find(x => x.CompareTag("Pistol")).GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        FollowMouse();
        SwitchItem();
    }
    private void FollowMouse() // реализовать этот метод в GameInput
    {
        MousePos = GameInput.Instance.MousePosForItems();
        PlayerPos = Player.Instance.PlayerPosition();
        MousePos.y -= PlayerPos.y;
        MousePos.x -= PlayerPos.x;
        transform.rotation = Quaternion.Euler(0f, 0f, RotateZ());
    }

    public float RotateZ()
    {
        float RotateZ = Mathf.Atan2(MousePos.y, MousePos.x) * Mathf.Rad2Deg; // Atan2 определяет угол( в радианах ), принимает две точки | Rad2Deg конвертирует радипны в градусы
        return RotateZ;
    }

    private void SwitchItem()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _activeItems.Find(x => x.CompareTag("FlashLight")).GetComponent<SpriteRenderer>().enabled = true;
            _activeItems.Find(x => x.CompareTag("Pistol")).GetComponent<SpriteRenderer>().enabled = false;
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _activeItems.Find(x => x.CompareTag("FlashLight")).GetComponent<SpriteRenderer>().enabled = false;
            _activeItems.Find(x => x.CompareTag("Pistol")).GetComponent<SpriteRenderer>().enabled = true;
           
        }
    }
}
