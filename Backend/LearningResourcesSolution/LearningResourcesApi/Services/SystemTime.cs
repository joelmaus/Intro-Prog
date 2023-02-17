namespace LearningResourcesApi.Services;

public class SystemTime : ISystemTime // implementation.
{
    public DateTimeOffset GetCurrent() => DateTimeOffset.Now;
}


public interface ISystemTime // job description
{
    DateTimeOffset GetCurrent();
}