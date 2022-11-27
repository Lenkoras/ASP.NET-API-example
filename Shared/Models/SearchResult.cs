namespace Shared.Models
{
    public class SearchResult
    {
        public static SearchResult Empty { get; } = new SearchResult()
        {
            Departments = Array.Empty<string>(),
            Employees = Array.Empty<string>()
        };

        public IEnumerable<string> Employees { get; set; }
        public IEnumerable<string> Departments { get; set; }
    }
}
