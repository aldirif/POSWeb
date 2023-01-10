using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Web.DataContext
{
    [Table("tbl_employee")]
    public class EmployeeEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("employee_name")]
        public String Name { get; set; }

        [Column("gender")]
        public String Gender { get; set; }

        [Column("address")]
        public String Address { get; set; }

        [Column("city")]
        public String City { get; set; }

        [Column("position")]
        public String Position { get; set; }
    }
}
