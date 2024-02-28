namespace Kira.Flight.Application.Features.Airplanes.Dto
{
    public record AirplaneDto
    {
        public AirplaneDto(Guid Id, string Name, string Model)
        {
            this.Id = Id;
            this.Name = Name;
            this.Model = Model;
        }

        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Model { get; init; }

        public void Deconstruct(out Guid Id, out string Name, out string Model)
        {
            Id = this.Id;
            Name = this.Name;
            Model = this.Model;
        }
    }
}
