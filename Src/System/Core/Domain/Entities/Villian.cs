namespace Guardian.System.Core.Domain.Entities
{
    public class Villian
    {
        public Guid Id { get; set; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}
