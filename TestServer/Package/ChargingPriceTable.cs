using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestServer.Models;

public class ChargingPriceTable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public String Vehicle { get; set; }
    public string Connector { get; set; } = string.Empty;
    public int MaxPower { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public double Price { get; set; }

}
