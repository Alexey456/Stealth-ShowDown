using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameInput : MonoBehaviour
{
    private PlayerinputActions _playerInputActions;

    public event EventHandler OnClickMouse;

    public static GameInput Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        _playerInputActions = new PlayerinputActions();
        _playerInputActions.Enable();
        _playerInputActions.ActionsBtn.BtnMouse.started += OnMouseClick;
    }

    private void OnMouseClick(InputAction.CallbackContext obj)
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClickMouse?.Invoke(this, EventArgs.Empty);
        }
    }

    public Vector2 GetMovementVector() // считываем вектор движения с клавиатуры
    {
        Vector2 inputValue = _playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputValue;
    }

    public Vector3 MousePosForItems() // находим положение мыши для предметов
    {
        Vector3 mousePosForItems = Input.mousePosition;
        return mousePosForItems;
    }
    
    public Vector3 MousePosForPlayers() // находим положение мыши для игрока
    {
        Vector3 MousePosForPlayers = Mouse.current.position.ReadValue();
        return MousePosForPlayers;
    }
}
