using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserApp_Demo.ViewModels
{
    public class VerfiyEmailOTPViewModel
    {
        [Required(ErrorMessage = "OTP Code is required.")]
        [DisplayName("OTP CODE")]
        public string OTP { get; set; }
    }
}
