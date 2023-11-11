using HikiStudio.LearnVocabulary.Utilities.Enums;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords;

namespace HikiStudio.LearnVocabulary.ViewModels.Courses
{
    public class CourseViewModel
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; } = String.Empty;

        public string CourseCode { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public CourseTypeEnum CourseType { get; set; }

        public DateTime DateCreated { get; set; }

        public string UserName { get; set; } = "hiki";

        public bool IsFavouriteCourse { get; set; }

        public List<VocabularyWordViewModel>? VocabularyWords { get; set; }
    }
}
