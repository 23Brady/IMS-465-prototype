using UnityEngine;

public class PlayerTurnSState: State
{
    private BattleManager battleManager;
    public PlayerTurnSState(BattleStateMachine stateMachine, BattleManager battleManager)
    {
        Machine = stateMachine;
        this.battleManager = battleManager;
    }
    public override void Enter()
    {
        UIManager.instance.STurn();

    }
    public override void Update()
    {

        if (UIManager.instance.choice == true)
        {
            Machine.ChangeState(new PlayerTurnRState(Machine, battleManager));
        }
    }
    public override void Exit()
    {
        Debug.Log("Leaving Player turn");
        UIManager.instance.choice = false;
    }
}
