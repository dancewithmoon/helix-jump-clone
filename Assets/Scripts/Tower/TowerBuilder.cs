using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private float _distanceBetweenPlatforms;
    [SerializeField] private int _maxPlatformRotation;

    [Header("Prefabs")]
    [SerializeField] private Beam _beamPrefab;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;

    private readonly float _startAndFinishAdditionalScale = 0.5f;

    public Tower BuildedTower { get; private set; }
    private float BeamScaleY => _levelCount * DistanceBetweenPlatformsCoef + _startAndFinishAdditionalScale*2 + _additionalScale;
    private float DistanceBetweenPlatformsCoef => _distanceBetweenPlatforms / 2f;

    public IEnumerator Build()
    {
        Beam beam = Instantiate(_beamPrefab, transform);
        beam.transform.localScale = new Vector3(beam.transform.localScale.x, BeamScaleY, beam.transform.localScale.z);

        yield return StartCoroutine(SpawnPlatforms(beam));
    }

    private IEnumerator SpawnPlatforms(Beam beam)
    {
        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale * 2;

        var startPlatform = SpawnPlatform(_startPlatform, spawnPosition, RotationType.Default) as StartPlatform;   
        spawnPosition.y -= _distanceBetweenPlatforms;

        yield return null;

        var platforms = new List<Platform>();
        for (int i = 0; i < _levelCount; i++)
        {
            Platform current = SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], spawnPosition, RotationType.Randomize);
            spawnPosition.y -= _distanceBetweenPlatforms;
            platforms.Add(current);
            yield return null;
        }

        var finishPlatform = SpawnPlatform(_finishPlatform, spawnPosition, RotationType.Default) as FinishPlatform;

        BuildedTower = new Tower(startPlatform, platforms, finishPlatform, beam);
    }

    private Platform SpawnPlatform(Platform prefab, Vector3 spawnPosition, RotationType rotationType)
    {
        Quaternion rotation;
        switch (rotationType)
        {
            case RotationType.Randomize:
                rotation = Quaternion.Euler(0, Random.Range(0, _maxPlatformRotation), 0);
                break;
            case RotationType.Default:
            default:
                rotation = Quaternion.identity;
                break;
        }
        return Instantiate(prefab, spawnPosition, rotation, transform);
    }


    private enum RotationType
    {
        Default,
        Randomize
    }
}
