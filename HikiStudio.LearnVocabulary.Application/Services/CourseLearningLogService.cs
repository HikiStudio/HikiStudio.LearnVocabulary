using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;
using HikiStudio.LearnVocabulary.Data.Entities;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs;
using HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs.DataRequest;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class CourseLearningLogService : ICourseLearningLogService
    {
        private readonly LanguageLearningDbContext _context;

        public CourseLearningLogService(LanguageLearningDbContext context)
        {
            _context = context;
        }

        public async Task<APIResponse<bool>> CreateCourseLearningLogAsync(CreateCourseLearningLogRequest request)
        {
            var course = await _context.Courses.FindAsync(request.CourseID);
            if (course is null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectNotFound(nameof(Course)) };

            var courseLearningLog = new CourseLearningLog()
            {
                CourseID = request.CourseID,
                Log = request.Log,
                Score = request.Score,
                LearningDate = request.LearningDate,
                DateCreated = DateTime.Now,
                CreatedBy = SystemConstants.AppSettings.CreateByDefault,
                IsDeleted = false
            };

            await _context.CourseLearningLogs.AddAsync(courseLearningLog);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return new APISuccessResponse<bool>() { Message = MessageConstants.CreateSuccess(nameof(CourseLearningLog)) };

            return new APIErrorResponse<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(CreateCourseLearningLogAsync), nameof(CourseLearningLog)) };
        }

        public async Task<PagedResponse<CourseLearningLogViewModel>> GetPagingCourseLearningLogByCourseIDAsync(PagedRequest request, long courseID)
        {
            IQueryable<CourseLearningLog> query = _context.CourseLearningLogs.Where(x => x.IsDeleted == false);

            if (courseID > 0)
            {
                query = query.Where(x => x.CourseID == courseID);
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(vw => (vw.Log != null && vw.Log.ToLower().Contains(request.SearchValue.ToLower()) || (vw.Score.ToString() == request.SearchValue.ToLower())));
            }

            query = query.OrderBy($"{request.SortColumn} {request.SortColumnDirection}");

            var totalRecords = await query.CountAsync();
            var vocabularyWordViewModels = await query
                .Skip(request.Skip)
                .Take(request.PageSize)
                .Select(x => new CourseLearningLogViewModel
                {
                    CourseID = x.CourseID,
                    Log = x.Log,
                    Score = x.Score,
                    LearningDate = x.LearningDate,
                    DateCreated = x.DateCreated,
                })
                .ToListAsync();

            var pagedResponse = new PagedResponse<CourseLearningLogViewModel>
            {
                Draw = request.Draw,
                RecordsFiltered = totalRecords,
                RecordsTotal = totalRecords,
                Data = vocabularyWordViewModels
            };

            return pagedResponse;
        }
    }
}
