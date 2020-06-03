using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.redhat.netcore.models.entities
{
    [Table("USERS", Schema = "NC")]
    public class User
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }
        [MaxLength(2)]
        public char DocumentType { get; set; }

        public List<Address> Addresses { get; set; }

    }
}
