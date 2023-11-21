namespace TrainManagementAPI.Models
{
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public string PNRNumber { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public string SourceStation { get; set; }
        public string DestinationStation { get; set; }
    }
}
