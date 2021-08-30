using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    private const float ADDITIONAL_SCALE = 3;
    private const float DISTANCE_BETWEEN_PLATFORMS = 2;

    private TowerSettings _settings;
    private readonly float _startAndFinishAdditionalScale = 0.5f;

    public Tower BuildedTower { get; private set; }
    private float BeamScaleY => _settings.LevelCount * DistanceBetweenPlatformsCoef + _startAndFinishAdditionalScale*2 + ADDITIONAL_SCALE;
    private float DistanceBetweenPlatformsCoef => DISTANCE_BETWEEN_PLATFORMS / 2f;

    public IEnumerator Build(TowerSettings settings)
    {
        _settings = settings;
        Beam beam = Instantiate(_settings.Beam, transform);
        beam.transform.localScale = new Vector3(beam.transform.localScale.x, BeamScaleY, beam.transform.localScale.z);

        yield return StartCoroutine(SpawnPlatforms(beam));
    }

    private IEnumerator SpawnPlatforms(Beam beam)
    {
        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - ADDITIONAL_SCALE * 2;

        var startPlatform = SpawnPlatform(_settings.StartPlatform, spawnPosition, RotationType.Default) as StartPlatform;   
        spawnPosition.y -= DISTANCE_BETWEEN_PLATFORMS;

        yield return null;

        var platforms = new List<Platform>();
        for (int i = 0; i < _settings.LevelCount; i++)
        {
            Platform current = SpawnPlatform(_settings.Platforms[Random.Range(0, _settings.Platforms.Count)], spawnPosition, RotationType.Randomize);
            spawnPosition.y -= DISTANCE_BETWEEN_PLATFORMS;
            platforms.Add(current);
            yield return null;
        }

        var finishPlatform = SpawnPlatform(_settings.FinishPlatform, spawnPosition, RotationType.Default) as FinishPlatform;

        BuildedTower = new Tower(startPlatform, platforms, finishPlatform, beam);
    }

    private Platform SpawnPlatform(Platform prefab, Vector3 spawnPosition, RotationType rotationType)
    {
        Quaternion rotation;
        switch (rotationType)
        {
            case RotationType.Randomize:
                rotation = Quaternion.Euler(0, Random.Range(0, _settings.MaxPlatformRotation), 0);
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
