using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace E4DataCapture.Models
{
    public class User
    {


        /*
         * The annotations are used for validation on the forms
         */


        // UserId will serve as unique identifier for when we delete or edit
        public string UserID { set; get; }


        [Required(ErrorMessage = "Please enter name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter surname")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter a valid surname")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Please enter cellphone number")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Cell number must have 10 digits")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Cell number must consist of numbers only")]
        [Display(Name = "Cell Number")]
        public string CellNumber { set; get; }

    }
}