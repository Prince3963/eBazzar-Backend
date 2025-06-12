﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace eBazzar.Model
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int address_id { get; set; }

        [Column("Number", TypeName = "varchar(50)")]
        public string? number { get; set; }

        [Column("Street", TypeName = "varchar(255)")]
        public string? street { get; set; }

        [Column("City", TypeName = "varchar(255)")]
        public string? city { get; set; }

        [Column("State", TypeName = "varchar(255)")]
        public string? state { get; set; }

        [Column("Zipcode", TypeName = "varchar(50)")]
        public string? zipCode { get; set; }

        [Column("Landmark", TypeName = "varchar(255)")]
        public string? landmark { get; set; }

        [Column("Country", TypeName = "varchar(255)")]
        public string? country { get; set; }

        [Column("isDefault", TypeName = "varchar(255)")]
        public string? isDefault { get; set; }
        public string? username { get; set; }
        public string? mobile { get; set; }

        [ForeignKey("user_id")]
        public int? user_id { get; set; }


        public ICollection <Orders>? orders { get; set; }
    }
}