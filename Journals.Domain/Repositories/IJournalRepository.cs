using Journals.Domain.Entities;

namespace Journals.Domain.Repositories;

public interface IJournalRepository
{
    Task<IEnumerable<Journal>> GetAll();
    Task<IEnumerable<Journal?>> GetByUserId(int id);
    Task<Journal?> GetById(int id);
    Task<int> Create(Journal journal);
}
