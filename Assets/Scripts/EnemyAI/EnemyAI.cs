using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private string targetName;
    
    private NavMeshAgent _navMeshAgent;
    private Transform _targetTransform;
    private Health _playerHealth;
    private float _attackSpeed = 1;
    private bool mayAttack = true;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _targetTransform = GameObject.Find(targetName).transform;
        _playerHealth = _targetTransform.GetComponent<Health>();
    }

    private void Update()
    {
        if (_targetTransform == null) return;

        var DistanceBetweenTarget = Vector3.Distance(transform.position, _targetTransform.position);

        if (_navMeshAgent.stoppingDistance < DistanceBetweenTarget)
        {
            _navMeshAgent.SetDestination(_targetTransform.position);
        }
        else
        {
            if (mayAttack)
            {
                StartCoroutine(Attack());
            }
        }
    }

    private IEnumerator Attack()
    {
        mayAttack = false;
        _playerHealth.TakeDamage(20);
        yield return new WaitForSeconds(_attackSpeed);
        mayAttack = true;
    }
}
