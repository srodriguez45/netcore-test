using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.redhat.netcore.models.entities
{

    [Table("ADDRESS", Schema = "NC")]
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string AddressLocation { get; set; }
        [MaxLength(2)]
        public char CountryCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }

    }
}
