using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Income
    {
        public double Amount { get; set; }

        [MaxLength(255)]
        public string Comment { get; set; }

        public DateTime Date { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}