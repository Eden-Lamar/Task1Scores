using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Task1Scores
{
    class Student
    {
        string name;
        int score;

        public string Name { get=> name; set => name = value; }
        public int Score { get=> score; set => score = value; }

        public Student(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
    }
}
