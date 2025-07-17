using UnityEngine;
public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private string _walkAnimation = "EnemyWalk";
    private string _runAnimation = "EnemyRun";
    private string _attackAnimation = "EnemyAttack";

    public void EnemyWalking()
    {
        _animator.Play(_walkAnimation);
    }
    public void EnemyRun()
    {
        _animator.Play(_runAnimation);
    }
    public void EnemyAttack()
    {
        _animator.Play(_attackAnimation);
    }
}
