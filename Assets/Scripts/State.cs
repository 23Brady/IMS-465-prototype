using UnityEngine;

public abstract class State: IState
{
    public BattleStateMachine Machine { get; protected set; }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
