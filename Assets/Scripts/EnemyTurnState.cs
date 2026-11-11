using UnityEngine;

public class EnemyTurnState : State
{
    private BattleManager battleManager;
    private float timer;
    private float duration = 5.0f;
    
    public EnemyTurnState(BattleStateMachine stateMachine, BattleManager battleManager)
    {
        Machine = stateMachine;
        this.battleManager = battleManager;
    }
    public override void Enter()
    {
        timer = 0.0f;
        battleManager.EnemyTurn = true;
        battleManager.battleBox.SetActive(true);
        Player.instance.EnemyTurn();
    }
    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duration)
        {
            Machine.ChangeState(new PlayerTurnKState(Machine, battleManager));
        }
    }
    public override void Exit()
    {
        battleManager.EnemyTurn = false;
        battleManager.battleBox.SetActive(false);
        
    }
}
