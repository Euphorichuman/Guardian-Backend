namespace Guardian.System.Core.Domain.Entities
{
    public class Villain
    {
        public Guid Id { get; set; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Origin { get; set; } = string.Empty;

        public string Power { get; set; } = string.Empty;
    }
}
