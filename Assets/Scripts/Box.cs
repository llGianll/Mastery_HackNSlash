using UnityEngine;

public class Box : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] float forceAmount = 10f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();    
    }

    public void TakeHit(Character hitBy)
    {
        var direction = transform.position - hitBy.transform.position;
        direction.Normalize();

        _rigidbody.AddForce(direction * forceAmount, ForceMode.Impulse);
    }
}
