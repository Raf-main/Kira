namespace Kira.Flight.Application.Features.Airports.Dto
{
    public record AirportDto
    {
        public AirportDto(Guid Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Guid Id { get; init; }
        public string Name { get; init; }

        public void Deconstruct(out Guid Id, out string Name)
        {
            Id = this.Id;
            Name = this.Name;
        }
    }
}
