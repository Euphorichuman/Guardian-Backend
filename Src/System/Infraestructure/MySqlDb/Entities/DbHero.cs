namespace Guardian.System.Infraestructure.MySqlDb.Entities
{
    public class DbHero
    {
        public Guid Id { get; set; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}
