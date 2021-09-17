using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private Rigidbody _self;
    private void Awake()
    {
        _self = GetComponent<Rigidbody>();
    }

    public void Pause()
    {
        _self.isKinematic = true;
    }
}
