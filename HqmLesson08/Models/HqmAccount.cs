using System.ComponentModel.DataAnnotations;

namespace HqmLesson08.Models
{
    public class HqmAccount
    {
        [Key]

        [Display(Name = "Ma")]
        public int HqmId { get; set; }

        [Display(Name ="Ho va ten")]
        [Required(ErrorMessage ="Ho va ten ko duoc de trong!!!")]
        [MinLength(6, ErrorMessage ="Ho ten phai it nhat 6 ky tu!!!")]
        [MaxLength(20, ErrorMessage ="Ho ten chi dc toi da 20 ky tu!!!")]
        public string HqmFullName { get; set; }

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Địa chỉ email không được để trống")]
        [DataType(DataType.EmailAddress)]
        public string HqmEmail { get; set; }

        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+?\d{1,3})?[-. ]?(\(?\d{3}\)?)[-. ]?\d{3}[-. ]?\d{4}$",
            ErrorMessage = "Số điện thoại không đúng định dạng")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string HqmPhone { get; set; }

        [Display(Name = "Địa chỉ thường trú")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(35, ErrorMessage = "Địa chỉ không vượt quá 35 ký tự")]
        public string HqmAddress { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string HqmAvatar { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime HqmBirthday { get; set; }

        [Display(Name = "Giới tính")]
        public string HqmGender { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage ="Mat khau ko dc de trong")]
        [MinLength(6, ErrorMessage ="Mat khau it nhat 6 ki tu")]
        public string HqmPassword { get; set; }

        [Display(Name = "Facebook")]
        public string HqmFacebook { get; set; }
    }
}
