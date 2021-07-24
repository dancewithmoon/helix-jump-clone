using System.Collections;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private float _distanceBetweenPlatforms;

    [Header("Prefabs")]
    [SerializeField] private Transform _beamPrefab;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;

    private readonly float _startAndFinishAdditionalScale = 0.5f;

    public float BeamScaleY => _levelCount * DistanceBetweenPlatformsCoef + _startAndFinishAdditionalScale*2 + _additionalScale;
    private float DistanceBetweenPlatformsCoef => _distanceBetweenPlatforms / 2f;


    private void Start()
    {
        Build();
    }

    private void Build()
    {
        Transform beam = Instantiate(_beamPrefab, transform);
        beam.localScale = new Vector3(beam.localScale.x, BeamScaleY, beam.localScale.z);

        StartCoroutine(SpawnPlatforms(beam));
    }

    private IEnumerator SpawnPlatforms(Transform beam)
    {
        Vector3 spawnPosition = beam.position;
        spawnPosition.y += beam.localScale.y - _additionalScale * 2;

        void SpawnPlatformWithDefaultParams(Platform platform)
        {
            var spawnParams = new SpawnParameters(spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), transform);
            SpawnPlatform(platform, spawnParams);
            spawnPosition.y -= _distanceBetweenPlatforms;
        }

        SpawnPlatformWithDefaultParams(_startPlatform);
        yield return null;

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatformWithDefaultParams(_platforms[Random.Range(0, _platforms.Length)]);
            yield return null;
        }

        SpawnPlatformWithDefaultParams(_finishPlatform);
    }

    private void SpawnPlatform(Platform platform, SpawnParameters spawnParameters)
    {
        Instantiate(platform, spawnParameters.position, spawnParameters.rotation, spawnParameters.parent);
    }

    private struct SpawnParameters
    {
        public Vector3 position;
        public Quaternion rotation;
        public Transform parent;

        public SpawnParameters(Vector3 position, Quaternion rotation, Transform parent)
        {
            this.position = position;
            this.rotation = rotation;
            this.parent = parent;
        }
    }
}
