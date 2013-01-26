using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainMemorySimulator
{

    public enum ScehdulerType
    {
        RoundRobin, FJFO, FIFO, 
    }

    public abstract class Memory
    {
        protected List<Job> runningQueue = new List<Job>();

        public int JobsLeft
        {
            get
            {
                int numOfJobsLeft = 0;

                foreach(Job iJob in JobQueue)
                {
                    if(!iJob.WasAllocated)
                    {
                        numOfJobsLeft++;
                    }
                }
                return numOfJobsLeft;
            }
        }

        public bool IsBestFit { get; set; }
        public ScehdulerType SchedulingType { get; set; }
        public abstract Job[] JobQueue { get; }
        public abstract void Update();
        public abstract bool IsFinished  { get; }
        public abstract Partition[] MemoryBlocks { get; }

        //Finds the first job that fits for a paticular partition
        protected Job FindJob(Partition space)
        {
            foreach (Job currentJob in JobQueue)
            {
                if (currentJob.MemorySpace <= space.CurrentJob.MemorySpace && !currentJob.WasAllocated)
                {
                    currentJob.WasAllocated = true;
                    return currentJob;
                }
            }

            return space.CurrentJob;
        }

        protected int CompareJobMemorySize(Job firstJob, Job secondJob)
        {
            return firstJob.MemorySpace - secondJob.MemorySpace;
        }

        protected int CompareJobName(Job firstJob, Job secondJob)
        {
            try
            {
                return int.Parse(firstJob.Name) - int.Parse(secondJob.Name);
            }
            catch (FormatException)
            {
                return firstJob.Name.CompareTo(secondJob.Name);
            }
        }

        protected int CompareJobTime(Job firstJob, Job secondJob)
        {
            return firstJob.Time - secondJob.Time;
        }

        protected void UpdateRunningQueue()
        {
            runningQueue.Clear();

            foreach (Partition iPartition in this.MemoryBlocks)
            {
                runningQueue.Add(iPartition.CurrentJob);
            }

            switch (this.SchedulingType)
            {
                case ScehdulerType.FIFO:
                    runningQueue.Sort(CompareJobName);
                    break;
                case ScehdulerType.FJFO:
                    runningQueue.Sort(CompareJobTime);
                    break;
            }
        }
    }
}
