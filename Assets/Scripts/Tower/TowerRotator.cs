using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1;

    private Rigidbody _self;
    private SwipeInput _input;

    private void Awake()
    {
        _input = FindObjectOfType<SwipeInput>();
        _self = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _input.Swiped += Rotate;
    }

    private void Rotate(float torque)
    {
        _self.AddTorque(Vector3.up * -torque * _rotateSpeed);
    }

    private void OnDisable()
    {
        _input.Swiped -= Rotate;
    }
}
