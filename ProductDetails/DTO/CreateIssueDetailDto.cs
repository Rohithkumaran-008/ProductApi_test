using System.ComponentModel.DataAnnotations.Schema;

namespace ProductDetails.DTO
{
    public class CreateIssueDetailDto
    {
        public int Id { get; set; }
        public int issueId { get; set; }
        public string cancel { get; set; }
    }
}
