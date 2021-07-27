using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    public void Break()
    {
        PlatformSegment[] segments = GetComponentsInChildren<PlatformSegment>();
        foreach(PlatformSegment segment in segments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
        StartCoroutine(DestroyPlatform());
    }

    private IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
