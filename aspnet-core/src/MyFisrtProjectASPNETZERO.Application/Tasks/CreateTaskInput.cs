using Abp.AutoMapper;
using MyFisrtProjectASPNETZERO.Tasks.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyFisrtProjectASPNETZERO.Tasks
{
    [AutoMapFrom(typeof(Task))]
    public class CreateTaskInput
    {
        [Required]
        [MaxLength(TaskEntityConfiguration.TitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(TaskEntityConfiguration.DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
