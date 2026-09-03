using UnityEngine;

public abstract class EnemyState
{
    protected EnemyAIController _enemyAIController;
    protected EnemyStateMachine _stateMachine;

    protected EnemyState(
        EnemyAIController enemy,
        EnemyStateMachine stateMachine)
    {
        _enemyAIController = enemy;
        _stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
    
}
