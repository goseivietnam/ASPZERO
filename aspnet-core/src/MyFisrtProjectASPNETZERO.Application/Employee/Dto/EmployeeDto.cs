using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyFisrtProjectASPNETZERO.Employee1.Configuration;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyFisrtProjectASPNETZERO.Employee.Dto
{
    [AutoMapFrom(typeof(MyFisrtProjectASPNETZERO.Employee1.Employee))]
    public class EmployeeDto:EntityDto<int>
    {
        [Required]
        [StringLength(EmployeeEntityConfiguration.NameMaxLenght)]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
