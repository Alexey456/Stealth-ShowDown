using UnityEngine;

public class StateMachine
{
    public IPlayerState _currentState { get; set; }

    public void Initialize(IPlayerState StartState)
    {
        _currentState = StartState;
        _currentState.Enter();
    }


    public void ChangeState(IPlayerState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

}
