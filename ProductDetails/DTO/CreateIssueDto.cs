using System.ComponentModel.DataAnnotations;

namespace ProductDetails.DTO
{
    public class CreateIssueDto
    {
       
        public int Id { get; set; }
      
        public string entityId { get; set; }
        
        public string indentType { get; set; }

        public string transferType { get; set; }
        
        public string fromUnit { get; set; }
       
        public string toUnit { get; set; }
       
        public string cencel { get; set; }

    }
}
