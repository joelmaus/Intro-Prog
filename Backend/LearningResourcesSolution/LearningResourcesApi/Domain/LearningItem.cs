namespace LearningResourcesApi.Domain;

public class LearningItem
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public string Link { get; set; } = "";

    public LearningItemType Type { get; set; } = LearningItemType.Video;
    
}

public enum LearningItemType {  Book, Video, Blog, Tutorial, Other }
