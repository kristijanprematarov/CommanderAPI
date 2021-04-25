namespace Commander.Profiles
{
    using AutoMapper;
    using Commander.DTOs;
    using Commander.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source to map from ---> map to Target
            CreateMap<Command, CommandReadDTO>();
            CreateMap<CommandCreateDTO, Command>();
            CreateMap<CommandUpdateDTO, Command>();
            CreateMap<Command, CommandUpdateDTO>();
        }
    }
}
