using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductDetails.Model
{
    public class IssueDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Issues")]
        public int issueId { get; set; }
        public Issues Issues { get; set; }

        public string AuId { get; private set; }
        [MaxLength(1)]
        public string cancel { get; set; }

        private static int latestAuId = 0;

        public IssueDetail()
        {
            // Generate a 4-character AuId in the format "AU01," "AU02," etc.
            latestAuId++;
            AuId = "AU" + latestAuId.ToString("D2");
        }

    }
}
