namespace Commander.Repository.Interfaces
{
    using Commander.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface ICommanderRepository
    {
        IEnumerable<Command> GetAppCommands();

        Command GetCommandById(int id);

        void CreateCommand(Command command);

        void UpdateCommand(Command command);

        void DeleteCommand(Command command);

        void SaveChanges();
    }
}
