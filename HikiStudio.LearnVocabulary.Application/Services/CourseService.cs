using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;
using HikiStudio.LearnVocabulary.Data.Entities;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.Utilities.Enums;
using HikiStudio.LearnVocabulary.ViewModels.AudioClips;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.Courses;
using HikiStudio.LearnVocabulary.ViewModels.Courses.DataRequest;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly LanguageLearningDbContext _context;

        public CourseService(LanguageLearningDbContext context)
        {
            _context = context;
        }

        public async Task<APIResponse<bool>> CreateCourseAsync(CreateCourseRequest request)
        {
            var course = new Course()
            {
                CourseName = request.CourseName,
                CourseCode = request.CourseCode,
                Description = request.Description,
                CreatedBy = SystemConstants.AppSettings.CreateByDefault,
                DateCreated = DateTime.Now,
                IsDeleted = false,
                CourseType = request.CourseType
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            foreach (var wordID in request.VocabularyWordIDs)
            {
                var courseInVocabularyWord = new CourseInVocabularyWord()
                {
                    CourseID = course.CourseID,
                    VocabularyWordID = wordID,
                    DateCreated = DateTime.Now,
                    CreatedBy = SystemConstants.AppSettings.CreateByDefault
                };

                _context.CourseInVocabularyWords.Add(courseInVocabularyWord);
            }

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return new APISuccessResponse<bool>() { Message = MessageConstants.CreateSuccess(nameof(Course)) };

            return new APIErrorResponse<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(CreateCourseAsync), nameof(Course)) };
        }

        public async Task<APIResponse<bool>> DeleteCourseAsync(int courseID)
        {
            var course = await _context.Courses.FindAsync(courseID);
            if (course is null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectNotFound(nameof(Course)) };

            course.IsDeleted = true;

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return new APISuccessResponse<bool>() { Message = MessageConstants.DeleteSuccess(nameof(Course)) };

            return new APIErrorResponse<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(DeleteCourseAsync), nameof(Course)) };
        }

        private async Task<int> GetDailyVocabularyLearningCount()
        {
            var query = from civw in _context.CourseInVocabularyWords
                        join c in _context.Courses on civw.CourseID equals c.CourseID
                        where c.CourseType == CourseTypeEnum.DailyVocabularyLearning
                        select civw;

            var result = await query.CountAsync();

            return result;
        }

        public async Task<APIResponse<bool>> GenerateDailyCourseAsync()
        {
            var currentTime = DateTime.Now.Date;

            var checkGenerateDailyCourseExist = await _context.Courses.FirstOrDefaultAsync(x => x.CourseType == CourseTypeEnum.DailyVocabularyLearning && x.DateCreated.Date == currentTime);

            if(checkGenerateDailyCourseExist != null) 
                return new APISuccessResponse<bool>() { Message = MessageConstants.GetObjectSuccess(nameof(GenerateDailyCourseAsync)) };

            var yesterday = currentTime.AddDays(-1);
            var courseInVocabularyWords = await _context.CourseInVocabularyWords.Where(x => x.DateCreated.Date <= yesterday).ToListAsync();

            int dailyVocabularyLearningCount = await GetDailyVocabularyLearningCount();
            var vocabularyWordIDs = await GetDailyVocabularyWordsAsync(dailyVocabularyLearningCount, dailyVocabularyLearningCount + SystemConstants.AppSettings.DailyLearnedVocabularyCount);

            var createCourseRequest = new CreateCourseRequest()
            {
                CourseName = $"Learn Vocabulary Every Day {DateTime.Now.ToString("dd/MM/yyyy")}",
                CourseType = CourseTypeEnum.DailyVocabularyLearning,
                Description = "Learn vocabulary every day for 90 consecutive days.",
                VocabularyWordIDs = vocabularyWordIDs
            };

            var result = await CreateCourseAsync(createCourseRequest);

            return result;
        }

        private async Task<List<long>> GetDailyVocabularyWordsAsync(int indexStart, int indexEnd)
        {
            var vocabularyWordIDs = new List<long>();

            var vocabularyWords = await _context.VocabularyWords.Where(x => x.VocabularyTypeID == 1).ToListAsync();
            int countVobularyWord = vocabularyWords.Count;

            for(int i = indexStart; i < indexEnd; i++)
            {
                vocabularyWordIDs.Add(vocabularyWords[i].VocabularyWordID);
            }

            return vocabularyWordIDs;
        }

        public async Task<List<CourseViewModel>> GetAllAsync()
        {
            var query = from c in _context.Courses
                        join fc in _context.FavouriteCourses on c.CourseID equals fc.CourseID into fc_group
                        from fc in fc_group.DefaultIfEmpty()
                        where c.CreatedBy == SystemConstants.AppSettings.CreateByDefault && c.IsDeleted == false
                        select new
                        {
                            Course = c,
                            IsFavourite = fc != null
                        };

            var result = await query.Select(x => new CourseViewModel()
            {
                CourseID = x.Course.CourseID,
                CourseName = x.Course.CourseName,
                CourseCode = x.Course.CourseCode,
                Description = x.Course.Description,
                DateCreated = x.Course.DateCreated,
                IsFavouriteCourse = x.IsFavourite
            }).ToListAsync();

            result = result.OrderByDescending(x => x.DateCreated).OrderByDescending(x => x.IsFavouriteCourse).ToList();

            return result;
        }

        public async Task<APIResponse<bool>> UpdateCourseAsync(UpdateCourseRequest request, int courseID)
        {
            var course = await _context.Courses.FindAsync(courseID);
            if (course is null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectNotFound(nameof(Course)) };

            course.CourseName = request.CourseName;
            course.CourseCode = request.CourseCode;
            course.Description = request.Description;
            course.CourseType = request.CourseType;

            var oldWords = await _context.CourseInVocabularyWords
                                        .Where(x => x.CourseID == courseID)
                                        .Select(x => x.VocabularyWordID)
                                        .ToListAsync();

            var newWords = request.VocabularyWordIDs;

            var wordsToRemove = oldWords.Except(newWords).ToList();

            foreach(var item in wordsToRemove)
            {
                var courseInVocabularyWord = await _context.CourseInVocabularyWords.FirstOrDefaultAsync(x => x.CourseID == courseID && x.VocabularyWordID == item);
                if(courseInVocabularyWord != null)
                {
                    _context.CourseInVocabularyWords.Remove(courseInVocabularyWord);
                }
            }

            var wordsToAdd = newWords.Except(oldWords).ToList();

            foreach (var wordID in wordsToAdd)
            {
                _context.CourseInVocabularyWords.Add(
                   new CourseInVocabularyWord { CourseID = courseID, VocabularyWordID = wordID, DateCreated = DateTime.Now, CreatedBy = SystemConstants.AppSettings.CreateByDefault }
                );
            }

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return new APISuccessResponse<bool>() { Message = MessageConstants.UpdateSuccess(nameof(Course)) };

            return new APIErrorResponse<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(UpdateCourseAsync), nameof(Course)) };
        }

        public async Task<PagedResponse<CourseViewModel>> GetPagingCourseAsync(PagedRequest request)
        {
            IQueryable<Course> query = _context.Courses.Where(x => x.IsDeleted == false);

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(vw => vw.CourseName.ToLower().Contains(request.SearchValue.ToLower()));
            }

            query = query.OrderBy($"{request.SortColumn} {request.SortColumnDirection}");

            var totalRecords = await query.CountAsync();
            var vocabularyWordViewModels = await query
                .Skip(request.Skip)
                .Take(request.PageSize)
                .Select(x => new CourseViewModel
                {
                    CourseID = x.CourseID,
                    CourseName = x.CourseName,
                    CourseCode = x.CourseCode,
                    Description = x.Description,
                    DateCreated = x.DateCreated,
                })
                .ToListAsync();

            var pagedResponse = new PagedResponse<CourseViewModel>
            {
                Draw = request.Draw,
                RecordsFiltered = totalRecords,
                RecordsTotal = totalRecords,
                Data = vocabularyWordViewModels
            };

            return pagedResponse;
        }

        public async Task<APIResponse<CourseViewModel>> GetCourseByCourseIDAsync(int courseID)
        {
            var course = await _context.Courses.FirstAsync(x => x.CourseID == courseID);
            if(course is null)
                return new APIErrorResponse<CourseViewModel>() { Message = MessageConstants.ObjectNotFound(nameof(Course)) };

            var courseInVocabularyWords = await _context.CourseInVocabularyWords.Where(x => x.CourseID == courseID).Select(x => new VocabularyWordViewModel()
            {
                VocabularyWordID = x.VocabularyWordID
            }).ToListAsync();

            var courseViewModel = new CourseViewModel()
            {
                CourseID = courseID,
                CourseName = course.CourseName,
                CourseCode = course.CourseCode,
                Description = course.Description,
                CourseType = course.CourseType,
                DateCreated= course.DateCreated,
                VocabularyWords = courseInVocabularyWords
            };

            return new APISuccessResponse<CourseViewModel>() { ResultObj = courseViewModel, Message = MessageConstants.GetObjectSuccess(nameof(Course)) };
        }
    }
}
