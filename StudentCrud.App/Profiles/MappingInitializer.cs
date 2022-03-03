using AutoMapper;
using StudentCrud.App.DTOs;
using StudentCrud.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.App.Profiles
{
    public class MappingInitializer : Profile
    {
        public MappingInitializer()
        {
            CreateMap<StudentDto, StudentEntity>().ReverseMap();
            CreateMap<StudentForCreationDto, StudentEntity>().ReverseMap();
        }
    }
}
