using System;
using System.ComponentModel.DataAnnotations;

    

namespace AtosLibrary.Presentation.Reader
{
    public class ReaderModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!"), 
         StringLength(35, ErrorMessage = "This field can have up to 35 characters."),
         Display(Name = "ReaderList Name")]
        public string Name { get; set; }

        [Display(Name="ReaderList Surname"),
         Required(ErrorMessage = "This field is required!"),
         MinLength(1),
         MaxLength(35)]
        public string Surname { get; set; }

        [Display(Name="ReaderList Gender"),
         Required(ErrorMessage = "This field is required!")]
        public string Gender { get; set; }

        [Display(Name = "Date of birth"),
         DataType(DataType.DateTime),
         Required(ErrorMessage = "This field is required!"),
         DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        // Range(typeof(DateTime), "01-01-1920")]
        public DateTime Birthday { get; set; }

        [Display(Name = "E-mail"),
         Required(ErrorMessage = "This field is required!"),
         RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid."),
         StringLength(64, ErrorMessage = "You've reached the maximum number of characters")]
        public string Email { get; set; }

        [Display(Name = "Phone number"),
         RegularExpression(@"[0-9]{9}", ErrorMessage = "Phone number is not valid"),
         MinLength(9, ErrorMessage = "Minimum number of characters is 9."),
         MaxLength(9)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }
    }
}