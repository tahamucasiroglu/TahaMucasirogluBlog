namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Options
{
    public record MaintenanceOption
    {
        public bool Enabled { get; init; }
        public DateTime EndDateTime { get; init; }
    }
}
