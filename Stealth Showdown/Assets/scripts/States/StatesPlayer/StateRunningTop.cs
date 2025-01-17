using UnityEngine;

public class StateRunningTop : IPlayerState
{
    private PlayerVisual _playerVisual;

    public StateRunningTop(PlayerVisual playerVisual)
    {
        _playerVisual = playerVisual;
    }
    public override void Enter()
    {
        _playerVisual._animator.SetBool(IS_RUNNING_TOP, true);
    }

    public override void Exit()
    {
        _playerVisual._animator.SetBool(IS_RUNNING_TOP, false);
    }
}
