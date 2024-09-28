using Journals.Domain.Entities;

namespace Journals.Application.Journals;

public interface IJournalsService
{
    Task<IEnumerable<Journal>> GetAll();
    Task<Journal?> GetById(int id);
    Task<int> Create(Journal journal);
}
