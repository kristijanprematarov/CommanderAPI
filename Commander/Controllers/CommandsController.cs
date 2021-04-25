namespace Commander.Controllers
{
    using AutoMapper;
    using Commander.DTOs;
    using Commander.Entities;
    using Commander.Service;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderService _commanderService;
        private readonly IMapper _mapper;

        public CommandsController(
            ICommanderService commanderService,
            IMapper mapper)
        {
            _commanderService = commanderService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commands = _commanderService.GetAppCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }

        [HttpGet("{id}", Name = "GetCommandById")] //api/commands/{id}
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var commandItem = _commanderService.GetCommandById(id);

            if (commandItem is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDTO>(commandItem));
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDto)
        {
            var commandEntity = _mapper.Map<Command>(commandCreateDto);

            _commanderService.CreateCommand(commandEntity);
            _commanderService.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDTO>(commandEntity);

            return CreatedAtRoute(nameof(GetCommandById), new { id = commandReadDto.Id }, commandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDTO commandUpdateDTO)
        {
            var commandEntity = _commanderService.GetCommandById(id);

            if (commandEntity is null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDTO, commandEntity);
            // this actually updated the existing entity so we don't need to add an Update method to our repository
            // the only thing we have to do is save changes !

            _commanderService.UpdateCommand(commandEntity);
            _commanderService.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDTO> jsonPatchDocument)
        {
            var commandEntity = _commanderService.GetCommandById(id);

            if (commandEntity is null)
            {
                return NotFound();
            }

            var commandPatchUpdateDTO = _mapper.Map<CommandUpdateDTO>(commandEntity);

            jsonPatchDocument.ApplyTo(commandPatchUpdateDTO, ModelState);

            if (!TryValidateModel(commandPatchUpdateDTO))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandPatchUpdateDTO, commandEntity);

            _commanderService.UpdateCommand(commandEntity);
            _commanderService.SaveChanges();

            return NoContent();
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = _commanderService.GetCommandById(id);

            if (command is null)
            {
                return NotFound();
            }

            _commanderService.DeleteCommand(command);
            _commanderService.SaveChanges();

            return NoContent();
        }


    }
}
