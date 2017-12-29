using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace Apps.Models.Sys
{
    public class SysSampleModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Age")]
        [Range(0, 10000)]
        public int? Age { get; set; }

        [Display(Name = "BoD")]
        public DateTime? Bir { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }


        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "CreateTime")]
        public DateTime? CreateTime { get; set; }

    }
}