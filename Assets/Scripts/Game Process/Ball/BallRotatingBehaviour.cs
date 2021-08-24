using UnityEngine;

[RequireComponent(typeof(BallJumpBehaviour))]
public class BallRotatingBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private BallJumpBehaviour _jump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _jump = GetComponent<BallJumpBehaviour>();
    }

    private void OnEnable()
    {
        _jump.Jumped += Rotate;
    }

    private void Rotate()
    {
        float x = Random.Range(0f, 1f);
        float y = Random.Range(0f, 1f);
        float z = Random.Range(0f, 1f);
        _rigidbody.AddTorque(new Vector3(x, y, z));
    }

    private void OnDisable()
    {
        _jump.Jumped -= Rotate;
    }
}
