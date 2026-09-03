using System.Collections;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    [Header("Debug¿ë Player Field")]
    [SerializeField] private GameObject _player;

    [Header("Enemy AI ¼³Á¤")]
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _stoppingDistance = 1.0f;
    [SerializeField] private float _patrolWaitTime = 2.0f;
    [SerializeField] private float _chaseDistance = 5.0f;

    private EnemyStateMachine _stateMachine;


    private NavMeshAgent _nav;
    private WaitForSeconds _patrolWaitSeconds;
    private Coroutine _switchPatrolPointCoroutine;

    private void Awake()
    {
        if (TryGetComponent<NavMeshAgent>(out var agent))
        {
            _nav = agent;
        }
        else
        {
            Debug.LogError("NavMeshAgent component not found on the GameObject.");
        }
        _patrolWaitSeconds = new WaitForSeconds(_patrolWaitTime);

        _stateMachine = new EnemyStateMachine();
        _stateMachine.Init(this);

    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public void SetDestination(DestinationType type)
    {
        _nav.SetDestination(type switch
        {
            DestinationType.StartPoint => _startPos.position,
            DestinationType.EndPoint => _endPos.position,
            DestinationType.Player => _player.transform.position,
            _ => _nav.destination
        });
    }

    public bool IsCloseToPlayer() => Mathf.Abs(Vector3.Distance(transform.position, _player.transform.position)) < _chaseDistance;


    public IEnumerator SwitchPatrolPoint()
    {
        if (_switchPatrolPointCoroutine != null)
        {
            StopCoroutine(_switchPatrolPointCoroutine);
        }
        Debug.Log("Switching Patrol Point");
        _switchPatrolPointCoroutine = null;
        yield return _patrolWaitSeconds;

        if (_nav.destination == _startPos.position)
        {
            _nav.SetDestination(_endPos.position);
        }
        else
        {
            _nav.SetDestination(_startPos.position);
        }
    }
    public bool HasReachedDestination()
    {
        if (_nav.pathPending)
            return false;

        if (_nav.remainingDistance > _stoppingDistance)
            return false;

        return !_nav.hasPath || _nav.velocity.sqrMagnitude == 0f;
    }




}

public enum DestinationType
{
    StartPoint,
    EndPoint,
    Player
}

