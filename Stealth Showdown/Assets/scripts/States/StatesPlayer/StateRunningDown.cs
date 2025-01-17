using UnityEngine;
using static PlayerVisual;

public class StateRunningDown : IPlayerState
{
    private PlayerVisual _playerVisual;

    public StateRunningDown(PlayerVisual playerVisual)
    {
        _playerVisual = playerVisual;
    }
    public override void Enter()
    {
        _playerVisual._animator.SetBool(IS_RUNNING_DOWN, true);
    }

    public override void Exit()
    {
        _playerVisual._animator.SetBool(IS_RUNNING_DOWN, false);
    }
}
