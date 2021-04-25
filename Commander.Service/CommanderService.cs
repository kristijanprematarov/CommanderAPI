namespace Commander.Service
{
    using Commander.Entities;
    using Commander.Repository.Interfaces;
    using System;
    using System.Collections.Generic;

    public class CommanderService : ICommanderService
    {
        private readonly ICommanderRepository _commanderRepository;

        public CommanderService(ICommanderRepository commanderRepository)
        {
            _commanderRepository = commanderRepository;
        }

        public void CreateCommand(Command command)
        {
            _commanderRepository.CreateCommand(command);
        }

        public void DeleteCommand(Command command)
        {
            _commanderRepository.DeleteCommand(command);
        }

        public IEnumerable<Command> GetAppCommands()
        {
            return _commanderRepository.GetAppCommands();
        }

        public Command GetCommandById(int id)
        {
            return _commanderRepository.GetCommandById(id);
        }

        public void SaveChanges()
        {
            _commanderRepository.SaveChanges();
        }

        public void UpdateCommand(Command command)
        {
            _commanderRepository.UpdateCommand(command);
        }
    }
}
