using Grpc.Core;
using Kira.Flight.API.GrpcServer.Protos;

namespace Kira.Flight.API.GrpcServer.Services;

public class FlightGrpcService : FlightService.FlightServiceBase
{
    public override Task<SeatResponse> GetSeat(GetSeatRequest request, ServerCallContext context)
    {
        return base.GetSeat(request, context);
    }

    public override Task<ReservedSeat> ReserveSeat(ReserveSeatRequest request, ServerCallContext context)
    {
        return base.ReserveSeat(request, context);
    }
}