using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerVisual : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    [SerializeField] private float BufferZoneForSwitchTopDown;

    private Vector2 _inputVector;

    private const string IS_RUNNING_LR = "isRunningLR";
    private const string IS_RUNNING_TOP = "isRunningTop";
    private const string IS_RUNNING_DOWN = "isRunningDown";

    private void Start()
    {
        BufferZoneForSwitchTopDown = 40f;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _inputVector = GameInput.Instance.GetMovementVector();
    }


    private void FixedUpdate()
    {
        FaceDirectionAnimation();
    }

    private void FaceDirectionAnimation()
    {
        Vector3 MousePos = GameInput.Instance.MousePosForPlayers();
        Vector3 PlayerPos = Player.Instance.PlayerPosition();

        if (MousePos.x > PlayerPos.x)
        {
            _spriteRenderer.flipX = false;
            StateWalkingOnOff(StateWalking.AnimWalkRL);
        }
        else if (MousePos.x < PlayerPos.x)
        {
            _spriteRenderer.flipX = true;
            StateWalkingOnOff(StateWalking.AnimWalkRL);
        }

        if (MousePos.y > (PlayerPos.y + BufferZoneForSwitchTopDown+18f))
        {
            StateWalkingOnOff(StateWalking.AnimWalkTop);
        }
        else if ((MousePos.y + BufferZoneForSwitchTopDown) < PlayerPos.y)
        {
            StateWalkingOnOff(StateWalking.AnimWalkDown);
        }

        if (_inputVector.x == 0 && _inputVector.y == 0) {
            StateWalkingOnOff(StateWalking.AnimIdle);
        }
    }

    private void StateWalkingOnOff(StateWalking stateWalking)
    {
        if (stateWalking == StateWalking.AnimWalkRL)
        {
            _animator.SetBool(IS_RUNNING_LR, true);
            _animator.SetBool(IS_RUNNING_TOP, false);
            _animator.SetBool(IS_RUNNING_DOWN, false);
        } else if(stateWalking == StateWalking.AnimWalkDown)
        {
            _animator.SetBool(IS_RUNNING_DOWN, true);
            _animator.SetBool(IS_RUNNING_TOP, false);
            _animator.SetBool(IS_RUNNING_LR, false);
        }
        else if (stateWalking == StateWalking.AnimWalkTop)
        {
            _animator.SetBool(IS_RUNNING_TOP, true);
            _animator.SetBool(IS_RUNNING_LR, false);
            _animator.SetBool(IS_RUNNING_DOWN, false);
        }
        else
        {
            _animator.SetBool(IS_RUNNING_TOP, false);
            _animator.SetBool(IS_RUNNING_LR, false);
            _animator.SetBool(IS_RUNNING_DOWN, false);
        }
    }

    private enum StateWalking
    {
        AnimIdle,
        AnimWalkRL,
        AnimWalkDown,
        AnimWalkTop
    }
}
