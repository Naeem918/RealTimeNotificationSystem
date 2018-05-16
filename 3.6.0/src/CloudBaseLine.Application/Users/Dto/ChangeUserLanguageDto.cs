using System.ComponentModel.DataAnnotations;

namespace CloudBaseLine.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}