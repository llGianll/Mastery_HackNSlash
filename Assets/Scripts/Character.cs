using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float _attackOffset = 1f;
    [SerializeField] float _attackRadius = 1f;

    public static List<Character> All = new List<Character>();

    Controller _controller;
    Animator _animator;

    Collider[] _attackResults;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _attackResults = new Collider[10];

        var animationImpactWatcher = GetComponentInChildren<AnimationImpactWatcher>();
        animationImpactWatcher.OnImpact += AnimationImpactWatcher_OnImpact;
    }
    /// <summary>
    /// Called by animation event via AnimationImpactWatcher
    /// </summary>
    private void AnimationImpactWatcher_OnImpact()
    {
        Vector3 position = transform.position + transform.forward * _attackOffset;
        int hitCount = Physics.OverlapSphereNonAlloc(position, _attackRadius, _attackResults);

        for (int i = 0; i < hitCount; i++)
        {
            var takeHit = _attackResults[i].GetComponent<ITakeHit>();

            if (takeHit != null)
                takeHit.TakeHit(this);
        }
    }

    public void SetController(Controller controller)
    {
        _controller = controller;
    }

    private void Update()
    {
        Vector3 direction = _controller.GetDirection();

        if (direction.magnitude > 0.25f)
        {
            transform.position += direction * Time.deltaTime * moveSpeed;
            transform.forward = direction * 360f;
            _animator.SetFloat("Speed", direction.magnitude);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }

        if (_controller.attackPressed)
        {
            _animator.SetTrigger("Attack");
        }
    }

    private void OnEnable()
    {
        if (All.Contains(this) == false)
            All.Add(this);
    }

    private void OnDisable()
    {
        if (All.Contains(this))
            All.Remove(this);
    }
}
