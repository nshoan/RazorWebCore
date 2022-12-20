using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorWeb6.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} phải nhập")]
        [StringLength(255,MinimumLength =5,ErrorMessage ="{0} phải dài từ {2} đến {1} kí tự")]
        [Display(Name ="Tiêu đề")]
        [Column(TypeName = "nvarchar")]
        public string? Title { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        [Required(ErrorMessage = "{0} phải nhập")]
        [Display(Name = "Ngày tạo")]
        public DateTime Created { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        public string? Content { get; set; }
    }
}
