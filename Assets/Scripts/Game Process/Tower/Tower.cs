using System.Collections.Generic;

public class Tower
{
    public StartPlatform StartPlatform { get; private set; }
    public List<Platform> Platforms { get; private set; }
    public FinishPlatform FinishPlatform { get; private set; }
    public Beam Beam { get; private set; }

    public Tower(StartPlatform startPlatform, List<Platform> platforms, FinishPlatform finishPlatform, Beam beam)
    {
        StartPlatform = startPlatform;
        Platforms = platforms;
        FinishPlatform = finishPlatform;
        Beam = beam;
    }
}
