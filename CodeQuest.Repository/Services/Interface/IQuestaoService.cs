using CodeQuest.Domain;
using CodeQuest.Repository.Dtos.Questao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Repository.Services.Interface
{
    public interface IQuestaoService
    {
        Task<string> AddQuestao(int userId, QuestaoDto model);
        Task<string> UpdateQuestao(int userId, Guid id, QuestaoDto model);
        Task<bool> DeleteQuestao(int userId, Guid questaoId);

        Task<QuestaoDto[]> GetAllQuestaoAsync();
        Task<QuestaoDto> GetQuestaoByIdAsync(Guid questaoId);
    }
}
