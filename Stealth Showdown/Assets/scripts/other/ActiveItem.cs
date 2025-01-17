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
        GameInput.Instance.OnNextSwitchItemsBtn += OnNextSwitchItems;
        GameInput.Instance.OnPrevSwitchItemsBtn += OnPrevSwitchItems;
        _activeItems.Find(x => x.CompareTag("FlashLight")).GetComponent<SpriteRenderer>().enabled = true;// находим объект в list по тегу и включаем спрайт
    }

    private int SwitchItemsGeneral()
    {
        int index = 0;
        for (int i = 0; i < _activeItems.Count; i++)
        {
            if (_activeItems[i].GetComponent<SpriteRenderer>().enabled == true)
            {
                _activeItems[i].GetComponent<SpriteRenderer>().enabled = false;
                index = i;
            }
            else
            {
                continue;
            }
        }
        return index;
    }

    private void OnNextSwitchItems(object sender, System.EventArgs e)
    {
        int index = SwitchItemsGeneral();
         _activeItems[(index + 1) % _activeItems.Count].GetComponent<SpriteRenderer>().enabled = true; // (index + 1) % _activeItems.Count если элемент окажется последним в списке то мы перейдем к первому
    }

    private void OnPrevSwitchItems(object sender, System.EventArgs e)
    {
        int index = SwitchItemsGeneral();
        _activeItems[(index + _activeItems.Count - 1) % _activeItems.Count].GetComponent<SpriteRenderer>().enabled = true;
    }

    private void Update()
    {
        FollowMouse();
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
}
