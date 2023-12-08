using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;
using HikiStudio.LearnVocabulary.Data.Entities;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships.DataRequest;
using Microsoft.EntityFrameworkCore;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class VocabularyRelationshipService : IVocabularyRelationshipService
    {
        private readonly LanguageLearningDbContext _context;

        public VocabularyRelationshipService(LanguageLearningDbContext context)
        {
            _context = context;
        }

        public async Task<APIResponse<bool>> AssignVocabularyRelationshipAsync(List<AssignVocabularyRelationshipRequest> requests, long vocabularyWordID)
        {
            if (requests.Count == 0)
                return new APIResponse<bool> { Message = MessageConstants.ObjectNotFound(nameof(AssignVocabularyRelationshipRequest)) };

            var currentVocabularyRelationships = await _context.VocabularyRelationships
                .Where(x => x.FirstVocabularyWordID == vocabularyWordID || x.SecondVocabularyWordID == vocabularyWordID)
                .ToListAsync();

            var listRemove = new List<VocabularyRelationship>();
            var listAdd = new List<VocabularyRelationship>();

            foreach (var currentVocabularyRelationship in currentVocabularyRelationships)
            {
                var existsInRequests = requests.Any(item =>
                    (item.FirstVocabularyWordID == currentVocabularyRelationship.FirstVocabularyWordID &&
                    item.SecondVocabularyWordID == currentVocabularyRelationship.SecondVocabularyWordID) ||
                    (item.FirstVocabularyWordID == currentVocabularyRelationship.SecondVocabularyWordID &&
                    item.SecondVocabularyWordID == currentVocabularyRelationship.FirstVocabularyWordID)
                );

                if (!existsInRequests)
                {
                    listRemove.Add(currentVocabularyRelationship);
                }
            }

            foreach (var item in requests)
            {
                var existingRelationship = currentVocabularyRelationships.FirstOrDefault(r =>
                    (r.FirstVocabularyWordID == item.FirstVocabularyWordID &&
                    r.SecondVocabularyWordID == item.SecondVocabularyWordID) ||
                    (r.FirstVocabularyWordID == item.SecondVocabularyWordID &&
                    r.SecondVocabularyWordID == item.FirstVocabularyWordID)
                );

                if (existingRelationship == null)
                {
                    listAdd.Add(new VocabularyRelationship()
                    {
                        FirstVocabularyWordID = item.FirstVocabularyWordID,
                        SecondVocabularyWordID = item.SecondVocabularyWordID,
                        VocabularyRelationshipType = item.VocabularyRelationshipType
                    });
                }
            }

            _context.VocabularyRelationships.RemoveRange(listRemove);
            await _context.VocabularyRelationships.AddRangeAsync(listAdd);

            var result = await _context.SaveChangesAsync();

            return new APISuccessResponse<bool>() { Message = MessageConstants.UpdateSuccess(nameof(VocabularyRelationship)) };
        }

        private static string GetWordByVocabularyRelationships(VocabularyWord firstVocabularyWord, VocabularyWord secondVocabularyWord, long vocabularyWordID)
        {
            if (vocabularyWordID != firstVocabularyWord.VocabularyWordID)
                return firstVocabularyWord.Word;

            if (vocabularyWordID != secondVocabularyWord.VocabularyWordID)
                return secondVocabularyWord.Word;

            return "";
        }

        public async Task<APIResponse<List<VocabularyRelationshipViewModel>>> GetVocabularyRelationshipByVocabularyWordIDAsync(long vocabularyWordID)
        {
            var query = from vr in _context.VocabularyRelationships
                        join vwf in _context.VocabularyWords on vr.FirstVocabularyWordID equals vwf.VocabularyWordID
                        join vws in _context.VocabularyWords on vr.SecondVocabularyWordID equals vws.VocabularyWordID
                        where vr.FirstVocabularyWordID == vocabularyWordID || vr.SecondVocabularyWordID == vocabularyWordID
                        select new { vr, vwf, vws };

            var result = await query.Select(x => new VocabularyRelationshipViewModel()
            {
                FirstVocabularyWordID = x.vr.FirstVocabularyWordID,
                SecondVocabularyWordID = x.vr.SecondVocabularyWordID,
                VocabularyRelationshipType = x.vr.VocabularyRelationshipType,
                Word = GetWordByVocabularyRelationships(x.vwf, x.vws, vocabularyWordID)
            }).ToListAsync();

            return new APISuccessResponse<List<VocabularyRelationshipViewModel>>() { ResultObj = result };
        }
    }
}
