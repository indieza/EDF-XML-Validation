using EdfXmlValidation.Models.EdfField;
using EdfXmlValidation.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdfXmlValidation.Models.EdfField
{
    public class EdfField
    {
        public EdfField()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsRequired = true;
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public bool IsRequired { get; set; }

        [ForeignKey(nameof(EdfFieldTypeRestriction)), Required]
        public string EdfFieldTypeRestrictionId { get; set; }

        public EdfFieldTypeRestriction EdfFieldTypeRestriction { get; set; }
    }
}