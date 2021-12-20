using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ITakeHit
{
    [SerializeField] GameObject _impactParticle;
    [SerializeField] int _maxHealth = 3;

    int _currentHealth;

    Animator _animator;
    Character _target;
    NavMeshAgent _navmeshAgent;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _navmeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_target == null)
        {
            _target = Character.All
                .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
                .FirstOrDefault();
        }
        else
        {
            _navmeshAgent.SetDestination(_target.transform.position);
        }


    }

    public void TakeHit(Character hitBy)
    {
        _currentHealth--;

        Instantiate(_impactParticle, transform.position + new Vector3(0, 2, 0), Quaternion.identity);

        if (_currentHealth <= 0)
            Die();
        else
            _animator.SetTrigger("Hit");
    }

    private void Die()
    {
        _animator.SetTrigger("Die");

        Destroy(gameObject, 6f);
    }
}
