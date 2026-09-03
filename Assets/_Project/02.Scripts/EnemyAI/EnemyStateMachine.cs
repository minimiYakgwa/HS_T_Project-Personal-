using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; }

    public EnemyPatrolState PatrolState { get; private set; }
    public EnemyChaseState ChaseState { get; private set; }
    public EnemyAttackState AttackState { get; private set; }

    public void Init(EnemyAIController _enemyAIController)
    {
        PatrolState = new EnemyPatrolState(_enemyAIController, this);
        ChaseState = new EnemyChaseState(_enemyAIController, this);
        AttackState = new EnemyAttackState(_enemyAIController, this);

        CurrentState = PatrolState;
        CurrentState.Enter();
    }

    public void ChangeState(EnemyState nextState)
    {
        CurrentState?.Exit();
        CurrentState = nextState;
        CurrentState.Enter();
    }

    public void Update()
    {
        CurrentState?.Update();
    }
}
