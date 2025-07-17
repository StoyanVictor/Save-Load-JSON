using UnityEngine;

public class AttackState : IEnemyState
{
    private EnemyAi _enemyAi;
    private EnemyAnimator _enemyAnimator;
    public AttackState(EnemyAi enemyAi,EnemyAnimator enemyAnimator)
    {
        _enemyAi = enemyAi;
        _enemyAnimator = enemyAnimator;
    }
    public void EnterState()
    {
        Debug.Log($"Im enter the attack state!");
    }
    public void Excute()
    {
        if(_enemyAi.CheckIfCanAttackPlayer())_enemyAnimator.EnemyAttack();
        else _enemyAi.SwitchState(new ChaseState(_enemyAi,_enemyAnimator));
    }
    public void ExitState()
    {
        Debug.Log($"Going away from current state");
    }
}