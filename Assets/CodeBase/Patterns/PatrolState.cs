using UnityEngine;

public class PatrolState : IEnemyState
{
    private EnemyAi _enemyAi;
    private EnemyAnimator _enemyAnimator;
    public PatrolState(EnemyAi enemyAi,EnemyAnimator enemyAnimator)
    {
        _enemyAi = enemyAi;
        _enemyAnimator = enemyAnimator;
    }
    public void EnterState()
    {
        Debug.Log($"Im enter the patrol state!");
        _enemyAi._AIAgent.SetDestination(_enemyAi.GetRandomPoint().position);
    }

    public void Excute()
    {
        _enemyAnimator.EnemyWalking();
        if (!_enemyAi._AIAgent.pathPending && _enemyAi._AIAgent.remainingDistance  < 0.5f)
        {
            Debug.Log($"{_enemyAi._AIAgent.remainingDistance}");
            Debug.Log($"Hi");
            _enemyAi._AIAgent.SetDestination(_enemyAi.GetRandomPoint().position);
        }
        else if (_enemyAi.CheckForPlayer()) _enemyAi.SwitchState(new ChaseState(_enemyAi,_enemyAnimator));
    }
    public void ExitState()
    {
        Debug.Log($"Going away from current state");
    }
}