

namespace LearningResourcesApi.IntegrationTests;

public class TestData
{

    public static DateTimeOffset BeforeCutoffTime { get; set; } = new DateTimeOffset(1969, 4, 20, 15, 59, 00, TimeSpan.FromHours(-5));
    public static DateTimeOffset AfterCutoffTime { get; set; } = new DateTimeOffset(1969, 4, 20, 16, 00, 00, TimeSpan.FromHours(-5));
}
