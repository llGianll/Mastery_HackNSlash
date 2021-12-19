using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float _attackOffset = 1f;
    [SerializeField] float _attackRadius = 1f;

    Controller _controller;
    Animator _animator;

    Collider[] _attackResults;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _attackResults = new Collider[10];
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
            Attack();
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
        Vector3 position = transform.position + transform.forward * _attackOffset;
        int hitCount = Physics.OverlapSphereNonAlloc(position, _attackRadius, _attackResults);

        for (int i = 0; i < hitCount; i++)
        {
            var box = _attackResults[i].GetComponent<Box>();

            if (box != null)
                box.TakeHit(this);
        }
    }
}
