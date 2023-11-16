namespace ProductDetails.DTO
{
    public class GetIssueDetailDto
    {
        public int Id { get; set; }
        public int issueId { get; set; }

        public string AuId { get; private set; }
        public string cancel { get; set; }
    }
}
