using ProductDetails.Model;

namespace ProductDetails.Repository.IRepository
{
    public interface IIssueDetailRepository : IGenericRepository<IssueDetail>
    {
        Task Update(IssueDetail entity);
    }
}
