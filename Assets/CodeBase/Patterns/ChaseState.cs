using UnityEngine;

public class ChaseState : IEnemyState
{
    private EnemyAi _enemyAi;
    private EnemyAnimator _enemyAnimator;
    public ChaseState(EnemyAi enemyAi,EnemyAnimator enemyAnimator)
    {
        _enemyAi = enemyAi;
        _enemyAnimator = enemyAnimator;
    }
    public void EnterState()
    {
        Debug.Log($"Im enter the chase state!");
    }

    public void Excute()
    {
        _enemyAnimator.EnemyRun();
        if (!_enemyAi._AIAgent.pathPending && _enemyAi._AIAgent.remainingDistance  < 0.5f)
        {
            _enemyAi._AIAgent.SetDestination(_enemyAi._currentPoint.position);
        }
        Debug.LogWarning(_enemyAi.CheckIfAiCanChasePlayer());
        if (!_enemyAi.CheckIfAiCanChasePlayer())
        {
            _enemyAi.SwitchState(new PatrolState(_enemyAi,_enemyAnimator));
        }
        if(_enemyAi.CheckIfCanAttackPlayer())_enemyAi.SwitchState(new AttackState(_enemyAi,_enemyAnimator));
    }
    public void ExitState()
    {
        Debug.Log($"Going away from current state");
    }
}