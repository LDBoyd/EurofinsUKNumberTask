using System.ComponentModel.DataAnnotations;

namespace EurofinsAPI.Models
{
    public class Number
    {
        public long Id { get; set; }

        [Required]
        [Range(0, 99)]
        public int MinValue { get; set; }

        [Required]
        [Range(1, 100)]
        public int MaxValue { get; set; }

        public DateTime datetime
        {
            get; private set;
        }

        public Number()
        {
            datetime = DateTime.Now;
        }

    }
}
