using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private BattleStateMachine stateMachine;
    public bool EnemyTurn;
    public GameObject battleBox;
    public GameObject player;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine = new BattleStateMachine();
        stateMachine.Initialize(new PlayerTurnKState(stateMachine, this));
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        battleBox = gameManager.battleBox;
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine?.Update();
    }
}
