namespace Reservation.Application.Common.DTOs;


public sealed record CityResponse(int Id, string FaName, List<string> Alternatives, string Key);