using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemplateApiService.Models.Users
{
    public class User
    {
        [Key]
        [Column("Id")]
        public Guid UserId { get; set; }

        [Required]
        [Column("Is_Active")]
        public bool IsActive { get; set; }

        [Required]
        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }

        [Column("Created_On")]
        public DateTime CreatedOn { get; set; }

        [Column("Modified_On")]
        public DateTime ModifiedOn { get; set; }

    }
}
