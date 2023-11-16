using Microsoft.EntityFrameworkCore;
using ProductDetails.Data;
using ProductDetails.Model;
using ProductDetails.Repository.IRepository;

namespace ProductDetails.Repository
{
    public class IssueRepository : GenericRepository<Issues>, IIssueRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public IssueRepository(ApplicationDbContext dbContect) : base(dbContect)
        {
            _dbContect = dbContect;
        }

        //public async Task<List<Issues>> GetByEntityId(string entityId)
        //{
        //    return await _dbContect.Issues.Where(i => i.entityId.ToLower() == entityId.ToLower()).ToListAsync();
        //}

        public async Task<List<Issues>> SearchByPartialEntityId(string partialEntityId)
        {
            return await _dbContect.Issues.Where(i => i.entityId.ToLower().Contains(partialEntityId.ToLower()))
        .ToListAsync();
        }

        public async Task Update(Issues entity)
        {
            _dbContect.Issues.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
