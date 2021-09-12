using UnityEngine;

public class BallSplashDrawer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _splashPrefab;
    [SerializeField] private float _yOffset = 0.13f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            InstantiateSplash(platformSegment, GetFirstContactPoint(collision));
        }
    }

    private void InstantiateSplash(PlatformSegment platformSegment, Vector3 position)
    {
        GameObject splash = Instantiate(_splashPrefab.gameObject, platformSegment.transform);
        splash.transform.position = position;
    }

    private Vector3 GetFirstContactPoint(Collision collision)
    {
        Vector3 contactPoint = collision.GetContact(0).point;
        contactPoint.y = transform.position.y - _yOffset;
        return contactPoint;
    }
}
