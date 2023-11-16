using System.ComponentModel.DataAnnotations;

namespace ProductDetails.Model
{
    public class Issues
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string entityId { get; set; }
        [Required]
        public string indentType { get; set; }
        [MaxLength(4)]
        public string docNo { get; private set; }

        [Required]
        public string transferType { get; set; }
        [Required]
        public string fromUnit { get; set; }
        [Required]
        public string toUnit { get; set; }
        [MaxLength(1)]
        public string cencel { get; set; }

        public IEnumerable<IssueDetail> Details { get; set; }

        private static int latestDocNo = 0;

        public Issues()
        {
            // Generate a 4-character doc_no in the format "DC01," "DC02," etc.
            latestDocNo++;
            docNo = "DC" + latestDocNo.ToString("D2");
        }
    }
}
