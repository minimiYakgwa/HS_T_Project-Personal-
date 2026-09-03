using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(EnemyAIController enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
    }
    public override void Enter()
    {
        Debug.Log("Entering Chase State");
        _enemyAIController.SetDestination(DestinationType.Player);
    }
    public override void Exit()
    {
        Debug.Log("Exiting Chase State");
    }
    public override void Update()
    {
        if (!_enemyAIController.IsCloseToPlayer())
        {
            _stateMachine.ChangeState(_stateMachine.PatrolState);
        }
    }
}

