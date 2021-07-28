using System.Collections;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _distanceToBall;

    private Ball _ball;

    private Vector3 _cameraPosition;
    private Vector3 _minimalBallPosition;
    private Vector3 _centeredPosition;

    private bool IsBallReachedMinimalPosition => _ball.transform.position.y < _minimalBallPosition.y;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _cameraPosition = _ball.transform.position;
        _minimalBallPosition = _ball.transform.position;

        Beam beam = FindObjectOfType<Beam>();
        _centeredPosition = beam.transform.position;

        TrackBall();
        StartCoroutine(WaitForBallTracking());
    }


    private IEnumerator WaitForBallTracking()
    {
        while (true)
        {
            yield return new WaitUntil(() => IsBallReachedMinimalPosition);
            TrackBall();
            _minimalBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        _centeredPosition.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (_centeredPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPosition -= direction * _distanceToBall;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
