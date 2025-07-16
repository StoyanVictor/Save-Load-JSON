using System;
using UnityEngine;

public interface IEnemyState
{
    public void EnterState();
    public void Excute();
    public void ExitState();
}
public class PatrolState : IEnemyState
{
    private EnemyAi _enemyAi;

    public PatrolState(EnemyAi enemyAi)
    {
        _enemyAi = enemyAi;
    }
    public void EnterState()
    {
        Debug.Log($"Im enter the patrol state!");
        _enemyAi._AIAgent.SetDestination(_enemyAi.GetRandomPoint().position);
    }

    public void Excute()
    {
        if (!_enemyAi._AIAgent.pathPending && _enemyAi._AIAgent.remainingDistance  < 0.5f)
        {
            Debug.Log($"{_enemyAi._AIAgent.remainingDistance}");
            Debug.Log($"Hi");
            _enemyAi._AIAgent.SetDestination(_enemyAi.GetRandomPoint().position);
        }
        else if (_enemyAi.CheckForPlayer()) _enemyAi.SwitchState(new ChaseState(_enemyAi));
    }
    public void ExitState()
    {
        Debug.Log($"Going away from current state");
    }
}
public class ChaseState : IEnemyState
{
    private EnemyAi _enemyAi;

    public ChaseState(EnemyAi enemyAi)
    {
        _enemyAi = enemyAi;
    }
    public void EnterState()
    {
        Debug.Log($"Im enter the chase state!");
    }

    public void Excute()
    {
        if (!_enemyAi._AIAgent.pathPending && _enemyAi._AIAgent.remainingDistance  < 0.5f)
        {
            _enemyAi._AIAgent.SetDestination(_enemyAi._currentPoint.position);
        }
        Debug.LogWarning(_enemyAi.CheckIfAiCanChasePlayer());
        if (!_enemyAi.CheckIfAiCanChasePlayer())
        {
            _enemyAi.SwitchState(new PatrolState(_enemyAi));
        }
    }
    public void ExitState()
    {
        Debug.Log($"Going away from current state");
    }
}