using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    public EnemyPatrolState(EnemyAIController enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Entering Patrol State");
        _enemyAIController.SetDestination(DestinationType.EndPoint);

    }

    public override void Exit()
    {
        Debug.Log("Exiting Patrol State");
    }

    public override void Update()
    {
        if (_enemyAIController.IsCloseToPlayer())
        {
            _stateMachine.ChangeState(_stateMachine.ChaseState);
        }
        else if (_enemyAIController.HasReachedDestination())
        {
            _enemyAIController.StartCoroutine(_enemyAIController.SwitchPatrolPoint());
        }
    }

    
}

