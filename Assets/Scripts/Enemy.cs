using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeHit
{
    [SerializeField] GameObject _impactParticle;

    Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void TakeHit(Character hitBy)
    {
        _animator.SetTrigger("Die");

        Instantiate(_impactParticle, transform.position + new Vector3(0, 2, 0), Quaternion.identity);

        Destroy(gameObject, 6f);
    }
}
