using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeHit
{
    [SerializeField] GameObject _impactParticle;
    [SerializeField] int _maxHealth = 3;

    int _currentHealth;

    Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
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
