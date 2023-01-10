using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Web.DataContext
{
    [Table("tbl_absensi")]
    public class AbsensiEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("emplooye_id")]
        public int EmployeeId { get; set; }

        [Column("absen_start-date")]
        public DateTime AbsenStartDate { get; set; }

        [Column("absen_end-date")]
        public DateTime AbsenEndDate { get; set; }

        [Column("location")]
        public String Location { get; set; }

        [Column("description")]
        public String Description { get; set; }
    }
}

