namespace Database.Models
{
    public class Faculty : Entity
    {
        public string Name { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}
