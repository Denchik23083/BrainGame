using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace BrainGame.Db.Entities
{
    public class Quiz
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answers { get; set; }
        
        public int CorrectAnswerId { get; set; }

        public Correct Correct { get; set; }
    }
}