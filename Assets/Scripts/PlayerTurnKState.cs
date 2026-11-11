using Unity.VisualScripting;
using UnityEngine;

public class PlayerTurnKState: State
{
    private BattleManager battleManager;
    private float timer;
    private float duration = 3.0f;
    public PlayerTurnKState(BattleStateMachine stateMachine, BattleManager battleManager)
    {
        Machine = stateMachine;
        this.battleManager = battleManager;
    }
    public override void Enter()
    {
        Debug.Log("Entered player state");
        timer = 0.0f;
        Player.instance.PlayerTurn();
    }
    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duration)
        {
            Machine.ChangeState(new EnemyTurnState(Machine, battleManager));
        }
    }
    public override void Exit()
    {
        Debug.Log("Leaving Player turn");
    }
}

