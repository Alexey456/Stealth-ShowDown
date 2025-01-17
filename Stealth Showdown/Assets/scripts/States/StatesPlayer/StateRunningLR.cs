using UnityEngine;

public class StateRunningLR : IPlayerState
{
    private PlayerVisual _playerVisual;

    public StateRunningLR(PlayerVisual playerVisual)
    {
        _playerVisual = playerVisual;
    }
    public override void Enter()
    {
        _playerVisual._animator.SetBool(IS_RUNNING_LR, true);
    }

    public override void Exit()
    {
        _playerVisual._animator.SetBool(IS_RUNNING_LR, false);
    }
}
