using UnityEngine;

public interface IState
{
    void Enter();
    void Update();
    void Exit();
}
public class BattleStateMachine
{
    public IState CurrentState { get; private set; }

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        CurrentState?.Enter();
    }
    public void ChangeState(IState newState)
    {
        if (newState == null || newState == CurrentState) return;

        CurrentState?.Exit(); // Guarantee cleanup of old state
        CurrentState = newState;
        CurrentState?.Enter(); // Guarantee initialization of new state
    }

    public void Update()
    {
        CurrentState?.Update();
    }

}
