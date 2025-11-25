namespace TestServer.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int VehicleId { get; set; }
        public string ChargingPortId { get; set; } = string.Empty;
        public DateTime ReservedAt { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}