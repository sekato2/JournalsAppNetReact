using Journals.Domain.Entities;
using Journals.Domain.Repositories;

namespace Journals.Application.Journals
{
    internal class JournalsService(IJournalRepository journalRepository) : IJournalsService
    {
        public async Task<int> Create(Journal journal)
        {
            int id = await journalRepository.Create(journal);
            return id;
        }

        public async Task<IEnumerable<Journal>> GetAll()
        {
            var journals = await journalRepository.GetAll();
            return journals;
        }

        public async Task<Journal?> GetById(int id)
        {
            var journal = await journalRepository.GetById(id);
            return journal;
        }

        public async Task<IEnumerable<Journal?>> GetByUserId(int id)
        {
            var journals = await journalRepository.GetByUserId(id);
            return journals;
        }
    }
}
