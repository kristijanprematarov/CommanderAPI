namespace Commander.Service
{
    using Commander.Entities;
    using System.Collections.Generic;
    public interface ICommanderService
    {
        IEnumerable<Command> GetAppCommands();

        Command GetCommandById(int id);

        void CreateCommand(Command command);

        void UpdateCommand(Command command);

        void DeleteCommand(Command command);

        void SaveChanges();
    }
}