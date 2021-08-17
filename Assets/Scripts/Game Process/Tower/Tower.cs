using System.Collections.Generic;

public class Tower
{
    public StartPlatform StartPlatform { get; private set; }
    public List<Platform> Platform { get; private set; }
    public FinishPlatform FinishPlatform { get; private set; }
    public Beam Beam { get; private set; }

    public Tower(StartPlatform startPlatform, List<Platform> platform, FinishPlatform finishPlatform, Beam beam)
    {
        StartPlatform = startPlatform;
        Platform = platform;
        FinishPlatform = finishPlatform;
        Beam = beam;
    }
}
