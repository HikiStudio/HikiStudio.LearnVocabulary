using HikiStudio.LearnVocabulary.Data.Entities.Base.Entities;

namespace HikiStudio.LearnVocabulary.Data.Entities
{
    public class FavouriteCourse : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int FavouriteCourseID { get; set; }

        public int CourseID { get; set; }

        public Guid UserID { get; set; }

        public Course? Course { get; set; }

        public AppUser? User { get; set; }
    }
}
