namespace Commander.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HowTo { get; set; }

        [Required]
        public string CommandLine { get; set; }

        [Required]
        public string Platform { get; set; }


    }
}
