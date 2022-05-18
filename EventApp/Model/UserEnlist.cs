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
        [MinLength(3, ErrorMessage = "Title must be atleast 3 characters")]
        public String Title { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description must be atleast 10 characters")]
        public String Description { get; set; }


    }
}
