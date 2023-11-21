using System;
using System.Collections.Generic;

namespace TrainManagement.Data.Entities;

public partial class TblTrain
{
    public int TrainId { get; set; }

    public string? TrainName { get; set; }

    public string? Pnrnumber { get; set; }
    public string PNRNumber { get; set; }
    public DateTime? ArrivalDateTime { get; set; }

    public DateTime? DepartureDateTime { get; set; }

    public string? SourceStation { get; set; }

    public string? DestinationStation { get; set; }
}
