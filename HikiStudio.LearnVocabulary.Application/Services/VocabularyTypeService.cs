using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;
using HikiStudio.LearnVocabulary.Data.Entities;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes.DataRequest;
using Microsoft.EntityFrameworkCore;

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
                VocabularyTypeName = request.VocabularyTypeName.Trim()
            };

            await _context.VocabularyTypes.AddAsync(vocabularyType);
            await _context.SaveChangesAsync();

            return new APISuccessResponse<bool>() { Message = MessageConstants.CreateSuccess(nameof(VocabularyType)) };
        }

        public Task<APIResponse<bool>> DeleteVocabularyTypeAsync(int vocabularyTypeID)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<List<VocabularyTypeViewModel>>> GetAllVocabularyTypesAsync()
        {
            var vocabularyTypes = await _context.VocabularyTypes.ToListAsync();

            var vocabularyTypeViewModels = vocabularyTypes.Select(vt => new VocabularyTypeViewModel
            {
                VocabularyTypeID = vt.VocabularyTypeID,
                VocabularyTypeName = vt.VocabularyTypeName
            }).ToList();

            return new APISuccessResponse<List<VocabularyTypeViewModel>>() { ResultObj = vocabularyTypeViewModels };
        }
    
        public async Task<APIResponse<bool>> UpdateVocabularyTypeAsync(UpdateVocabularyTypeRequest request, int vocabularyTypeID)
        {
            var vocabularyType = await _context.VocabularyTypes.FirstOrDefaultAsync(vt => vt.VocabularyTypeID == vocabularyTypeID);

            if (vocabularyType == null)
            {
                return new APIErrorResponse<bool>() { Message = MessageConstants.ObjectNotFound(nameof(VocabularyType)) };
            }

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
