using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tower : MonoBehaviour
{
    private List<Platform> _platforms;
    private Rigidbody _self;
    
    public IReadOnlyList<Platform> Platforms => _platforms.AsReadOnly();
    public StartPlatform StartPlatform { get; private set; }
    public FinishPlatform FinishPlatform { get; private set; }
    public Beam Beam { get; private set; }

    public int PlatformsCount => _platforms.Count + 2;

    private void Awake()
    {
        _self = GetComponent<Rigidbody>();
    }

    public void Init(StartPlatform startPlatform, List<Platform> platforms, FinishPlatform finishPlatform, Beam beam)
    {
        StartPlatform = startPlatform;
        _platforms = platforms;
        FinishPlatform = finishPlatform;
        Beam = beam;
    }

    public void Pause()
    {
        _self.isKinematic = true;
    }
}
