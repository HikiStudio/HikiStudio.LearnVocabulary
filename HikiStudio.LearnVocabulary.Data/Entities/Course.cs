using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;
using HikiStudio.LearnVocabulary.Utilities.Enums;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    public class Course : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; } = String.Empty;

        public string CourseCode { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public CourseTypeEnum CourseType {  get; set; }

        public List<CourseInVocabularyWord> CourseInVocabularyWords { get; set; } = new List<CourseInVocabularyWord>();

        public List<CourseLearningLog>? CourseLearningLogs { get; set; }

        public List<FavouriteCourse>? FavouriteCourses { get; set; }

    }
}