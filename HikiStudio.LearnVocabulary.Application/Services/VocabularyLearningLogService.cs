using CSharpFunctionalExtensions;
using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;
using HikiStudio.LearnVocabulary.Data.Entities;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyLearningLogs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class VocabularyLearningLogService : IVocabularyLearningLogService
    {
        private readonly LanguageLearningDbContext _context;

        public VocabularyLearningLogService(LanguageLearningDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<VocabularyLearningLogViewModel>> GetPagingVocabularyLearningLogAsync(PagedRequest request)
        {
            IQueryable<VocabularyLearningLog> query = _context.VocabularyLearningLogs;

            query = query.OrderBy($"{request.SortColumn} {request.SortColumnDirection}");

            var totalRecords = await query.CountAsync();
            var vocabularyWordViewModels = await query
                .Skip(request.Skip)
                .Take(request.PageSize)
                .Select(x => new VocabularyLearningLogViewModel
                {
                    VocabularyLearningLogID = x.VocabularyLearningLogID,
                    UserID = x.UserID,
                    Duration = x.Duration,
                    Notes = x.Notes,
                    DeviceInfo = x.DeviceInfo,
                    DateCreated = x.DateCreated
                })
                .ToListAsync();

            var pagedResponse = new PagedResponse<VocabularyLearningLogViewModel>
            {
                Draw = request.Draw,
                RecordsFiltered = totalRecords,
                RecordsTotal = totalRecords,
                Data = vocabularyWordViewModels
            };

            return pagedResponse;
        }

        public async Task<APIResponse<StatisticsVocabularyLearningViewModel>> GetStatisticsVocabularyLearningAsync(int days)
        {
            IQueryable<VocabularyLearningLog> query = _context.VocabularyLearningLogs;

            var vocabularyLearningLogs = await query.OrderByDescending(x => x.DateCreated)
                .Take(days)
                .Select(x => new VocabularyLearningLogViewModel
                {
                    VocabularyLearningLogID = x.VocabularyLearningLogID,
                    UserID = x.UserID,
                    Duration = x.Duration,
                    Notes = x.Notes,
                    DeviceInfo = x.DeviceInfo,
                    DateCreated = x.DateCreated
                })
                .ToListAsync();


            List<string> labels = new List<string>();
            List<TimeSpan?> dateTimes = new List<TimeSpan?>();
            foreach (var item in vocabularyLearningLogs)
            {
                labels.Add(item.DateCreated.ToString("dd/MM/yyyy"));
                dateTimes.Add(item.Duration);
            }

            var result = new StatisticsVocabularyLearningViewModel() { Days = labels, DateTimes = dateTimes };

            return new APISuccessResponse<StatisticsVocabularyLearningViewModel>() { ResultObj = result, Message = MessageConstants.GetObjectSuccess(nameof(StatisticsVocabularyLearningViewModel))};
        }

        public async Task<APIResponse<VocabularyLearningLogViewModel>> ReadVocabularyLearningLog()
        {
            var now = DateTime.Now;

            var log = await _context.VocabularyLearningLogs.FirstOrDefaultAsync(x => x.DateCreated.Date == now.Date);
            if (log is null)
            {
                var vocabularyLearningLog = new VocabularyLearningLog()
                {
                    UserID = SystemConstants.AppSettings.CreateByDefault,
                    Duration = new TimeSpan(0, 0, 0),
                    Notes = null,
                    DeviceInfo = null,
                    CreatedBy = SystemConstants.AppSettings.CreateByDefault,
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                };

                await _context.VocabularyLearningLogs.AddAsync(vocabularyLearningLog);
                await _context.SaveChangesAsync();

                var result = new VocabularyLearningLogViewModel() { Hours = 0, Minutes = 0, Seconds = 0 };

                return new APISuccessResponse<VocabularyLearningLogViewModel>() { ResultObj = result, Message = MessageConstants.CreateSuccess(nameof(VocabularyLearningLog)) };
            }
            else
            {
                if (log.Duration.HasValue)
                {
                    var duration = log.Duration.Value;
                    var result = new VocabularyLearningLogViewModel()
                    {
                        Hours = duration.Hours,
                        Minutes = duration.Minutes,
                        Seconds = duration.Seconds
                    };

                    return new APISuccessResponse<VocabularyLearningLogViewModel>() { ResultObj = result, Message = MessageConstants.GetObjectSuccess(nameof(VocabularyLearningLog)) };
                }
                else
                {
                    return new APISuccessResponse<VocabularyLearningLogViewModel>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(ReadVocabularyLearningLog), "duration") };
                }
            }
        }

        public async Task<APIResponse<bool>> WriteVocabularyLearningLog(TimeSpan duration)
        {
            var now = DateTime.Now;

            var log = await _context.VocabularyLearningLogs.FirstOrDefaultAsync(x => x.DateCreated.Date == now.Date);
            if (log is null)
            {
                var vocabularyLearningLog = new VocabularyLearningLog()
                {
                    UserID = SystemConstants.AppSettings.CreateByDefault,
                    Duration = new TimeSpan(0, 0, 0),
                    Notes = null,
                    DeviceInfo = null,
                    CreatedBy = SystemConstants.AppSettings.CreateByDefault,
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                };

                await _context.VocabularyLearningLogs.AddAsync(vocabularyLearningLog);
                await _context.SaveChangesAsync();

                return new APISuccessResponse<bool>() { Message = MessageConstants.CreateSuccess(nameof(VocabularyLearningLog)) };
            }
            else
            {
                log.Duration = duration;
                await _context.SaveChangesAsync();

                return new APISuccessResponse<bool>() { Message = MessageConstants.UpdateSuccess(nameof(VocabularyLearningLog)) };
            }
        }
    }
}
