using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private SwipeInput _input;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _input.Swiped += Rotate;
    }

    private void Rotate(float torque)
    {
        _rigidbody.AddTorque(Vector3.up * -torque);
    }

    private void OnDisable()
    {
        _input.Swiped -= Rotate;
    }
}
