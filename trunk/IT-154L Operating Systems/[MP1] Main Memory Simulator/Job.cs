using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainMemorySimulator
{
    public class Job
    {
        public int Number {get; set;}
        public int Time { get; set; }
        public int TimeLeft { get; set; }
        public int MemorySpace { get; set; }
        public bool IsEmpty { get; set; }
        public bool WasAllocated { get; set; }

        public Job(int number, int time, int space)
        {
            Number = number;
            Time = time;
            this.TimeLeft = time;
            MemorySpace = space;
            IsEmpty = false;
            WasAllocated = false;
        }

        public Job(int number, int time, int space, bool isEmpty)
        {
            Number = number;
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
