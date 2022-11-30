namespace Guardian.System.Infraestructure.MySqlDb.Entities
{
    public class DbVillain
    {
        public Guid Id { get; set; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Origin { get; set; } = string.Empty;

        public string Power { get; set; } = string.Empty;
    }
}
