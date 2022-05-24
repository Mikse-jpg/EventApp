using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Model
{
    public class UserEnlist
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters")]
        public String Title { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description must be at least 20 characters")]
        public String Description { get; set; }


    }
}
