using UnityEngine;

public abstract class IPlayerState
{
    protected const string IS_RUNNING_LR = "isRunningLR";
    protected const string IS_RUNNING_TOP = "isRunningTop";
    protected const string IS_RUNNING_DOWN = "isRunningDown";

    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void Exit() { }
}
