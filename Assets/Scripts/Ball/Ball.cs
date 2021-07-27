using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out TriggerSegment triggerSegment))
        {
            triggerSegment.GetComponentInParent<Platform>().Break();
        }
    }
}
