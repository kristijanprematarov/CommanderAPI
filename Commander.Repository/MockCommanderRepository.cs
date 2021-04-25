namespace Commander.Repository
{
    using Commander.Entities;
    using Commander.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class MockCommanderRepository : ICommanderRepository
    {
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil an egg", CommandLine = "Boil water", Platform = "Cooking" },
                new Command { Id = 1, HowTo = "Cut bread", CommandLine = "get a knife", Platform = "Chopping" },
                new Command { Id = 2, HowTo = "Make cup of tea", CommandLine = "Place teabag in cup", Platform = "Kettle and cup" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", CommandLine = "Boil water", Platform = "Cooking" };
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
