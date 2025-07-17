using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    public Transform _currentPoint;
    private IEnemyState _enemyState;
    public NavMeshAgent _AIAgent;
    public float _zoneOfPlayerChecking;
    public float _zoneOfPlayerLosing;
    public float _zoneOfPlayerAttacking;
    
    public Transform GetRandomPoint()
    {
        var randomPoint = Random.Range(0, _points.Length);
        return _points[randomPoint];
    }
    public bool CheckForPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, _zoneOfPlayerChecking);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                _currentPoint = collider.gameObject.transform;
                print($"Hellow player");
                return true;
            }
            else
                continue;
        }
        return false;
    }
    public bool CheckIfCanAttackPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, _zoneOfPlayerAttacking);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player")) return true;
            else continue;
        }
        return false;
    }
    public bool CheckIfAiCanChasePlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, _zoneOfPlayerLosing);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player")) return true;
            else continue;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position,_zoneOfPlayerChecking);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position,_zoneOfPlayerLosing);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,_zoneOfPlayerAttacking);
    }

    public void SwitchState(IEnemyState state)
    {
        if (_enemyState != null)
        {
            _enemyState.ExitState();
            state.EnterState();
            _enemyState = state;
        }
        else
        {
            state.EnterState();
            _enemyState = state;        
        }
    }
    private void Update()
    {
        _enemyState.Excute();
        Debug.LogWarning(_enemyState);
    }

    private void Awake()
    {
        _enemyState = new PatrolState(this,_enemyAnimator);
        _enemyState.EnterState();
    }
}