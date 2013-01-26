using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainMemorySimulator
{
    public class FixedPartitionMemory : Memory
    {
        private List<Job> allocationQueue;
        private List<Partition> memoryBlocks;
        
        public override Job[] JobQueue
        {
            get
            {
                return allocationQueue.ToArray();
            }
        }
        public override bool IsFinished
        {            
            get
            {
                bool isEmpty = true;
                int i = 0;

                while(isEmpty && i < memoryBlocks.Count)
                {
                    isEmpty = memoryBlocks[i].CurrentJob.IsEmpty;
                    i++;
                }

                return isEmpty;
            }
        }
        public override Partition[] MemoryBlocks { get { return memoryBlocks.ToArray(); } }

        public FixedPartitionMemory(List<Partition> memoryBlocks, List<Job> jobQueue, bool isBestFit, ScehdulerType SchedulingType)
        {
            IsBestFit = isBestFit;
            this.SchedulingType = SchedulingType;
            this.memoryBlocks = memoryBlocks;         
            this.allocationQueue = jobQueue;
            Comparison<Job> jobComparison;

            if (IsBestFit)
            {
                jobComparison = new Comparison<Job>(CompareJobMemorySize);
                allocationQueue.Sort(jobComparison);
            }

            Allocate();
            UpdateRunningQueue();
        }

        //Simulates an Interval Cycle of main memory.
        //Removes the job from the partition where the job's time is zero
        public override void Update()
        {
            runningQueue[0].Update();

            foreach (Partition iParition in this.memoryBlocks)
            {
                if (iParition.CurrentJob.TimeLeft <= 0)
                {
                    ((FixedPartition)iParition).Dump();
                    if (Allocate())
                    {
                        UpdateRunningQueue();
                    }
                    else
                    {
                        runningQueue.RemoveAt(0);
                    }
                }
            }
        }

        //Assigns a job that fits to a partition. The job chosen depends on the allocation method Best-Fit/First-Fit.
        private bool Allocate()
        {
            bool hasAllocated = false;
            foreach(FixedPartition currentPartitition in this.memoryBlocks)
            {
                if (currentPartitition.CurrentJob.IsEmpty)
                {
                    currentPartitition.CurrentJob = FindJob(currentPartitition);
                    hasAllocated = true;
                }
            }

            return hasAllocated;
        }
    }
}