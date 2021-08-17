using UnityEngine;

public class BallSplashDrawer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _splashPrefab;
    [SerializeField] private float _yOffset = 0.13f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            Vector3 contactPoint = collision.GetContact(0).point;
            contactPoint.y = transform.position.y - _yOffset;
            GameObject splash = Instantiate(_splashPrefab.gameObject, platformSegment.transform);          
            splash.transform.position = contactPoint;
        }
    }
}
