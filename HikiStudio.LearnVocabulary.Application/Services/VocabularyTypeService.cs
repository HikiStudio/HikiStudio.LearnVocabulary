using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;
using HikiStudio.LearnVocabulary.Data.Entities;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.Courses;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes.DataRequest;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class VocabularyTypeService : IVocabularyTypeService
    {
        private readonly LanguageLearningDbContext _context;

        public VocabularyTypeService(LanguageLearningDbContext context)
        {
            _context = context;
        }

        public async Task<APIResponse<bool>> CreateVocabularyTypeAsync(CreateVocabularyTypeRequest request)
        {
            var existingVocabularyType = await _context.VocabularyTypes.FirstOrDefaultAsync(vt => vt.VocabularyTypeName.Trim().ToLower() == request.VocabularyTypeName.Trim().ToLower());
            if (existingVocabularyType != null)
            {
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectAlreadyExists(nameof(VocabularyType)) };
            }

            var vocabularyType = new VocabularyType()
            {
                VocabularyTypeName = request.VocabularyTypeName.Trim(),
                DateCreated = DateTime.UtcNow,
                CreatedBy = SystemConstants.AppSettings.CreateByDefault,
            };

            await _context.VocabularyTypes.AddAsync(vocabularyType);
            await _context.SaveChangesAsync();

            return new APISuccessResponse<bool>() { Message = MessageConstants.CreateSuccess(nameof(VocabularyType)) };
        }

        public async Task<APIResponse<bool>> DeleteVocabularyTypeAsync(int vocabularyTypeID)
        {
            var vocabularyWord = await _context.VocabularyTypes.FirstOrDefaultAsync(vw => vw.VocabularyTypeID == vocabularyTypeID);

            if (vocabularyWord is null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectNotFound(nameof(VocabularyWord)) };

            vocabularyWord.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new APISuccessResponse<bool>() { Message = MessageConstants.DeleteSuccess(nameof(VocabularyWord)) };
        }

        public async Task<APIResponse<List<VocabularyTypeViewModel>>> GetAllVocabularyTypesAsync()
        {
            var vocabularyTypes = await _context.VocabularyTypes.Where(x => !x.IsDeleted).ToListAsync();

            var vocabularyTypeViewModels = vocabularyTypes.Select(vt => new VocabularyTypeViewModel
            {
                VocabularyTypeID = vt.VocabularyTypeID,
                VocabularyTypeName = vt.VocabularyTypeName
            }).ToList();

            return new APISuccessResponse<List<VocabularyTypeViewModel>>() { ResultObj = vocabularyTypeViewModels };
        }

        public async Task<PagedResponse<VocabularyTypeViewModel>> GetPagingVocabularyTypesAsync(PagedRequest request)
        {
            IQueryable<VocabularyType> query = _context.VocabularyTypes.Where(x => x.IsDeleted == false);

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(vw => vw.VocabularyTypeName.ToLower().Contains(request.SearchValue.ToLower()));
            }

            query = query.OrderBy($"{request.SortColumn} {request.SortColumnDirection}");

            var totalRecords = await query.CountAsync();
            var vocabularyWordViewModels = await query
                .Skip(request.Skip)
                .Take(request.PageSize)
                .Select(x => new VocabularyTypeViewModel
                {
                    VocabularyTypeID = x.VocabularyTypeID,
                    VocabularyTypeName = x.VocabularyTypeName,
                    DateCreated = x.DateCreated,
                })
                .ToListAsync();

            var pagedResponse = new PagedResponse<VocabularyTypeViewModel>
            {
                Draw = request.Draw,
                RecordsFiltered = totalRecords,
                RecordsTotal = totalRecords,
                Data = vocabularyWordViewModels
            };

            return pagedResponse;
        }

        public async Task<APIResponse<VocabularyTypeViewModel>> GetVocabularyTypeByVocabularyTypeIDAsync(int vocabularyTypeID)
        {
            var vocabularyType = await _context.VocabularyTypes.FirstOrDefaultAsync(x => x.VocabularyTypeID == vocabularyTypeID && !x.IsDeleted);
            if(vocabularyType is null)
                return new APIErrorResponse<VocabularyTypeViewModel> { ResultObj = new VocabularyTypeViewModel()};

            return new APISuccessResponse<VocabularyTypeViewModel>()
            {
                ResultObj = new VocabularyTypeViewModel()
                {
                    VocabularyTypeID = vocabularyTypeID,
                    VocabularyTypeName = vocabularyType.VocabularyTypeName,
                    DateCreated = vocabularyType.DateCreated
                }
            };
        }

        public async Task<APIResponse<bool>> UpdateVocabularyTypeAsync(UpdateVocabularyTypeRequest request, int vocabularyTypeID)
        {
            var vocabularyType = await _context.VocabularyTypes.FirstOrDefaultAsync(vt => vt.VocabularyTypeID == vocabularyTypeID && !vt.IsDeleted);

            if (vocabularyType == null)
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectNotFound(nameof(VocabularyType)) };

            var existingVocabularyType = await _context.VocabularyTypes.FirstOrDefaultAsync(vt => vt.VocabularyTypeName.Trim().ToLower() == request.VocabularyTypeName.Trim().ToLower() && vt.VocabularyTypeID != vocabularyTypeID);
            if (existingVocabularyType != null)
            {
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectAlreadyExists(nameof(VocabularyType)) };
            }

            vocabularyType.VocabularyTypeName = request.VocabularyTypeName.Trim();

            await _context.SaveChangesAsync();

            return new APISuccessResponse<bool>() { Message = MessageConstants.UpdateSuccess(nameof(VocabularyType)) };
        }
    }
}
