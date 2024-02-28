using MediatR;

namespace Kira.Flight.Application.Features.Flights.CreateFlight
{
    public record CreateFlightCommand : IRequest<Guid>
    {
        public CreateFlightCommand(Guid PlaneId, Guid FromAirportId, Guid ToAirportId, decimal Price, DateTimeOffset DateTime)
        {
            this.PlaneId = PlaneId;
            this.FromAirportId = FromAirportId;
            this.ToAirportId = ToAirportId;
            this.Price = Price;
            this.DateTime = DateTime;
        }

        public Guid PlaneId { get; init; }
        public Guid FromAirportId { get; init; }
        public Guid ToAirportId { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset DateTime { get; init; }

        public void Deconstruct(out Guid PlaneId, out Guid FromAirportId, out Guid ToAirportId, out decimal Price, out DateTimeOffset DateTime)
        {
            PlaneId = this.PlaneId;
            FromAirportId = this.FromAirportId;
            ToAirportId = this.ToAirportId;
            Price = this.Price;
            DateTime = this.DateTime;
        }
    }
}
