using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "Tower Settings")]
public class TowerSettings : ScriptableObject
{
    [SerializeField] private int _levelCount;
    [SerializeField] private int _maxPlatformRotation;

    [Header("Prefabs")]
    [SerializeField] private Beam _beamPrefab;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;

    public int LevelCount => _levelCount;
    public int MaxPlatformRotation => _maxPlatformRotation;

    public Beam Beam => _beamPrefab;
    public StartPlatform StartPlatform => _startPlatform;
    public FinishPlatform FinishPlatform => _finishPlatform;
    public IReadOnlyList<Platform> Platforms => _platforms;

    private void OnValidate()
    {
        if (_levelCount < 0)
        {
            _levelCount = 0;
        }

        if (_maxPlatformRotation < 0)
        {
            _maxPlatformRotation = 0;
        }
    }
}
