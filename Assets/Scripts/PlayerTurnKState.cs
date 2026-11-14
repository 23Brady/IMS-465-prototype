using Unity.VisualScripting;
using UnityEngine;

public class PlayerTurnKState: State
{
    private BattleManager battleManager;
    public PlayerTurnKState(BattleStateMachine stateMachine, BattleManager battleManager)
    {
        Machine = stateMachine;
        this.battleManager = battleManager;
    }
    public override void Enter()
    {
        Player.instance.PlayerTurn();
        UIManager.instance.KTurn();
    }
    public override void Update()
    {
        
        if (UIManager.instance.choice == true)
        {
            Machine.ChangeState(new PlayerTurnSState(Machine, battleManager));
        }
    }
    public override void Exit()
    {
        Debug.Log("Leaving Player turn");
        UIManager.instance.choice = false;
    }
}

