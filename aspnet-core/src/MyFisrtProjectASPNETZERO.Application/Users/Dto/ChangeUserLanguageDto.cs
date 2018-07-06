using System.ComponentModel.DataAnnotations;

namespace MyFisrtProjectASPNETZERO.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}