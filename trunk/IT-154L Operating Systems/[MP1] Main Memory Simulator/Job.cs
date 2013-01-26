using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainMemorySimulator
{
    public class Job
    {
        public string Name {get; set;}
        public int Time { get; set; }
        public int TimeLeft { get; set; }
        public int MemorySpace { get; set; }
        public bool IsEmpty { get; set; }
        public bool WasAllocated { get; set; }

        public Job(string name, int time, int space)
        {
            Name = name;
            Time = time;
            this.TimeLeft = time;
            MemorySpace = space;
            IsEmpty = false;
            WasAllocated = false;
        }

        public Job(string name, int time, int space, bool isEmpty)
        {
            Name = name;
            Time = time;
            this.TimeLeft = time;
            MemorySpace = space;
            IsEmpty = isEmpty;
            WasAllocated = false;
        }

        public void Update()
        {
            if (!this.IsEmpty)
            {
                this.TimeLeft--;
            }
        }
    }
}
