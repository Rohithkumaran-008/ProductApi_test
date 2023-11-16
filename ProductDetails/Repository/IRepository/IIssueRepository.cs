using ProductDetails.Model;
using System.Diagnostics.Metrics;

namespace ProductDetails.Repository.IRepository
{
    public interface IIssueRepository : IGenericRepository<Issues>
    {
        Task Update(Issues entity);
        Task<List<Issues>> SearchByPartialEntityId(string partialEntityId);
    }
}
