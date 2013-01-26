using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainMemorySimulator
{
    public class FixedPartition : Partition
    {
        public FixedPartition(int memorySize)
            : base(memorySize)
        {
            this.MemoryCapacity = memorySize;
        }

        public FixedPartition(Job newJob, int memorySize) : base(newJob)
        {
            this.CurrentJob = newJob;
            this.MemoryCapacity = memorySize;
        }

        public int MemoryCapacity { get; set; }

        public new void Dump(int size)
        {
            this.Dump();
        }

        public void Dump()
        {
            this.CurrentJob = new Job("Empty", 100, MemoryCapacity, true);
        }
    }
}
