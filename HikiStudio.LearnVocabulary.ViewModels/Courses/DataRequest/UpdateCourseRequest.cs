using HikiStudio.LearnVocabulary.Utilities.Enums;

namespace HikiStudio.LearnVocabulary.ViewModels.Courses.DataRequest
{
    public class UpdateCourseRequest
    {
        public string CourseName { get; set; } = String.Empty;

        public string CourseCode
        {
            get
            {
                return GenerateCourseCodeFromName(CourseName);
            }
        }

        public string Description { get; set; } = String.Empty;

        public CourseTypeEnum CourseType { get; set; }

        public List<long> VocabularyWordIDs { get; set; } = new List<long>();

        private string GenerateCourseCodeFromName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "";

            var words = name.Split(' ');
            var code = "";

            foreach (var word in words)
            {
                code += char.ToUpper(word[0]);
            }

            return code;
        }
    }
}
