using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Proiect_NETMaui.Models
{
    public class Restaurant
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^0\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123' si sa inceapa cu 0")]
        public string PhoneNumber { get; set; }
        [RegularExpression(@"^(https?|ftp):\/\/[^\s/$.?#].[^\s]*$", ErrorMessage = "URL-ul nu este valid.")]
        public string Website { get; set; }
        [Range(0, 5, ErrorMessage = "Ratingul trebuie să fie între 0 și 5")]
        public string TotalRating { get; set; }
    }
}
