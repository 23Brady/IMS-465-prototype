using UnityEngine;

public class PlayerTurnRState: State
{
    private BattleManager battleManager;
    public PlayerTurnRState(BattleStateMachine stateMachine, BattleManager battleManager)
    {
        Machine = stateMachine;
        this.battleManager = battleManager;
    }
    public override void Enter()
    {
        UIManager.instance.RTurn();

    }
    public override void Update()
    {

        if (UIManager.instance.choice == true)
        {
            Machine.ChangeState(new EnemyTurnState(Machine, battleManager));
        }
    }
    public override void Exit()
    {
        Debug.Log("Leaving Player turn");
        UIManager.instance.choice = false;
    }
}
