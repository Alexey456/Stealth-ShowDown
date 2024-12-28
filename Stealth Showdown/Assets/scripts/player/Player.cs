using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[SelectionBase]
public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 6f;
    private Vector2 _inputVector;
    public static Player Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _inputVector = GameInput.Instance.GetMovementVector();
    }

    private void FixedUpdate()
    {
        MovementPlayer();
    }
    private void MovementPlayer()
    {
        _rb.MovePosition(_rb.position + _inputVector * (_speed * Time.fixedDeltaTime));
    }

    public Vector3 PlayerPosition() // ищем положение игрока
    {
        Vector3 PlayerPos = Camera.main.WorldToScreenPoint(transform.position);
        return PlayerPos;
    }
}
