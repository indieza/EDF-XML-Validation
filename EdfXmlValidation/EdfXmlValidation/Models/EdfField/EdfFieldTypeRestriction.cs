using EdfXmlValidation.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EdfXmlValidation.Models.EdfField
{
    public class EdfFieldTypeRestriction
    {
        public EdfFieldTypeRestriction()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(EdfFieldType))]
        public EdfFieldType EdfFieldType { get; set; }

        public int? MinValue { get; set; }

        public int? MaxValue { get; set; }

        public int? ConcreteValue { get; set; }

        public string PossibleChoices { get; set; }

        public virtual ICollection<EdfField> EdfFields { get; set; } = new HashSet<EdfField>();
    }
}