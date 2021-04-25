namespace Commander.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommandReadDTO
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string CommandLine { get; set; }

        //property Platform removed for illustration, our DTOs don't need to expose everything our EntityModel has        
    }
}
