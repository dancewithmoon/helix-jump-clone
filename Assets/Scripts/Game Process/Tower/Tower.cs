using System.Collections.Generic;

public class Tower
{
    public List<Platform> _platforms;

    public IReadOnlyList<Platform> Platforms => _platforms.AsReadOnly();
    public StartPlatform StartPlatform { get; private set; }
    public FinishPlatform FinishPlatform { get; private set; }
    public Beam Beam { get; private set; }

    public int PlatformsCount => _platforms.Count + 2;

    public Tower(StartPlatform startPlatform, List<Platform> platforms, FinishPlatform finishPlatform, Beam beam)
    {
        StartPlatform = startPlatform;
        _platforms = platforms;
        FinishPlatform = finishPlatform;
        Beam = beam;
    }
}
