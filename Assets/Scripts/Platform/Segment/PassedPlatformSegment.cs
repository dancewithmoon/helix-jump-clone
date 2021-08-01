using UnityEngine;

public class PassedPlatformSegment : PlatformSegment
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            GetComponentInParent<Platform>().Break();
        }
    }
}
