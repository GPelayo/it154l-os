using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainMemorySimulator
{
    public class Partition
    {
        public Job CurrentJob   { get; set; }

        public Partition NextPartition { get; set; }

        public Partition(int size)
        {
            this.Dump(size);
        }

        public Partition(Job newJob)
        {
            this.CurrentJob = newJob;
        }

        public void Dump(int size)
        {
            this.CurrentJob = new Job("Empty", 100, size, true);
        }

        public void ResetJob()
        {
            this.CurrentJob.TimeLeft = this.CurrentJob.Time;
            this.CurrentJob.WasAllocated = false;
        }
    }
}