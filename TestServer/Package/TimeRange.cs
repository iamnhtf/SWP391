using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestServer.Package
{
    public class TimeRange
    {
        [Key]
        public int Id { get; set; }
        public string Range { get; set; } = string.Empty;
    }
}
