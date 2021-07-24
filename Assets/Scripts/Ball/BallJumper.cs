using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private bool _jumped;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (_jumped)
        {
            return;
        }
        StartCoroutine(ProcessJump());
    }

    private IEnumerator ProcessJump()
    {
        _jumped = true;
        _rigidbody.velocity = Vector3.zero;

        yield return null;

        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _jumped = false;
    }
}
