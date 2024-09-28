using Journals.Domain.Entities;
using Journals.Domain.Repositories;
using Journals.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Journals.Infraestructure.Repositories;

internal class JournalRepository(JournalDbContext dbContext) : IJournalRepository
{
    public async Task<int> Create(Journal journal)
    {
        dbContext.Journals.Add(journal);
        await dbContext.SaveChangesAsync();
        return journal.Id;
    }

    public async Task<IEnumerable<Journal>> GetAll()
    {
        var journals = await dbContext.Journals.ToListAsync();
        return journals;
    }

    public async Task<Journal?> GetById(int id)
    {
        var journal = await dbContext.Journals.FirstOrDefaultAsync(y => y.Id == id);
        return journal;
    }

    public async Task<IEnumerable<Journal?>> GetByUserId(int id)
    {
        var journals = await dbContext.Journals.Where(y => y.OwnerId == id).ToListAsync();
        return journals;
    }
}
