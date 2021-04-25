namespace Commander.Repository
{
    using Commander.Data;
    using Commander.Entities;
    using Commander.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommanderRepository : ICommanderRepository
    {
        private readonly DataContext _context;

        public CommanderRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            _context.Commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            _context.Commands.Remove(command);
        }

        public IEnumerable<Command> GetAppCommands()
        {
            return _context.Commands.AsEnumerable();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateCommand(Command command)
        {
            //
        }
    }
}
