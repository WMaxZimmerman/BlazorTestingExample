namespace BlazorTestingExample.Core.Common.Helpers;

public interface IGuidHelper
{
    Guid New();
}

public class GuidHelper: IGuidHelper
{
    public Guid New()
    {
        return Guid.NewGuid();
    }
}
