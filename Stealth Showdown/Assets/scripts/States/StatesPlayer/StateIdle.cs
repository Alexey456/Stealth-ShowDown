using UnityEngine;

public class StateIdle : IPlayerState
{

    private PlayerVisual _playerVisual;

    public StateIdle(PlayerVisual playerVisual)
    {
        _playerVisual = playerVisual;
    }
    public override void Enter()
    {
        _playerVisual._animator.SetBool(IS_RUNNING_DOWN, false);
        _playerVisual._animator.SetBool(IS_RUNNING_LR, false);
        _playerVisual._animator.SetBool(IS_RUNNING_TOP, false);
    }
}
