using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerVisual : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Animator _animator;
    [SerializeField] private float BufferZoneForSwitchTopDown;
    private StateMachine _stateMachine;
    private Vector2 _inputVector;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new StateIdle(this));
        BufferZoneForSwitchTopDown = 40f;
    }


    private void Update()
    {
        _inputVector = GameInput.Instance.GetMovementVector();
    }


    private void FixedUpdate()
    {
        if (Mathf.Abs(_inputVector.x) > 0 || Mathf.Abs(_inputVector.y) > 0)
        {
            FaceDirectionAnimation();
        }
        else
        {
            _stateMachine.ChangeState(new StateIdle(this));
        }
    }

    private void FaceDirectionAnimation()
    {
        Vector3 MousePos = GameInput.Instance.MousePosForPlayers();
        Vector3 PlayerPos = Player.Instance.PlayerPosition();
        if (MousePos.x > PlayerPos.x)
        {
            flipXOFF();
            _stateMachine.ChangeState(new StateRunningLR(this));
        }
        if (MousePos.x < PlayerPos.x)
        {
            flipXON();
            _stateMachine.ChangeState(new StateRunningLR(this));
        }
        if (MousePos.y > (PlayerPos.y + BufferZoneForSwitchTopDown + 18f))
        {
            _stateMachine.ChangeState(new StateRunningTop(this));
        }
        if ((MousePos.y + BufferZoneForSwitchTopDown) < PlayerPos.y)
        {
            _stateMachine.ChangeState(new StateRunningDown(this));
        }
    }

    public void flipXON()
    {
        _spriteRenderer.flipX = true;
    }

    public void flipXOFF()
    {
        _spriteRenderer.flipX = false;
    }
}
