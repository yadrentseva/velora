namespace velora.Models
{
    public class PaginatedResult
    {
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageNumber { get; set; }
        public EventResponseDto[] Events { get; set; }

    }
}
