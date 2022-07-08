using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlLite_Net6
{
    public class tbl_User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID{ get; set; }
        public string? Email{ get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Password { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
