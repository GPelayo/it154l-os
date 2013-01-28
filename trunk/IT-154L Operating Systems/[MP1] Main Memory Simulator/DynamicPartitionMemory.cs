using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainMemorySimulator
{
    public class DynamicPartitionMemory : Memory
    {
        private int mainMemorySize;
        private List<Job> originalJobQueue;
        private Partition firstPartition;                      
        private Partition lastPartition;

        public int Size { get{ return mainMemorySize; } }

        public override Job[] JobQueue {
            get
            {
                return originalJobQueue.ToArray();
            }
        }

        public override bool IsFinished
        {
            get
            {
                Partition readPartition = this.firstPartition;

                try
                {
                    while (readPartition != this.lastPartition)
                    {
                        if (!readPartition.CurrentJob.IsEmpty)
                        {
                            return false;
                        }

                        readPartition = readPartition.NextPartition;
                    }
                }
                catch (NullReferenceException)
                {
                    return true;
                }

                return this.lastPartition.CurrentJob.IsEmpty;
            }
        }

        public override Partition[] MemoryBlocks
        {
            get
            {
                List<Partition> output = new List<Partition>();
                Partition readPartition = this.firstPartition; 
                bool hasPartitionsLeft = true;

                while(hasPartitionsLeft)
                {
                    hasPartitionsLeft = readPartition != this.lastPartition;
                    output.Add(readPartition);

                    readPartition = readPartition.NextPartition;
                }

                return output.ToArray();
            }
        }

        public DynamicPartitionMemory(int size, List<Job> jobQueue, bool isBestFit, bool isFJFS)
        {
            IsBestFit = isBestFit;
            this.mainMemorySize = size;         
            this.originalJobQueue = jobQueue;
            Comparison<Job> jobComparison;

            if (isFJFS)
            {
                jobComparison = new Comparison<Job>(CompareJobTime);
            }
            else
            {
                jobComparison = new Comparison<Job>(CompareJobName);
            }

            originalJobQueue.Sort(jobComparison);

            if (IsBestFit)
            {
                jobComparison = new Comparison<Job>(CompareJobMemorySize);
                originalJobQueue.Sort(jobComparison);
            }

            //Quickly allocates the first jobs in the memory. Faster than allocated since the main memory is already empty 
            int memoryLeft = this.mainMemorySize - JobQueue[0].MemorySpace;

            firstPartition = new Partition(JobQueue[0]);
            Partition currentPartition = firstPartition;
            JobQueue[0].WasAllocated = true;

            for (int i = 1; i < JobQueue.Length && memoryLeft > 0; i++)
            {
                if (memoryLeft >= JobQueue[i].MemorySpace)
                {
                    JobQueue[i].WasAllocated = true;
                    currentPartition.NextPartition = new Partition(JobQueue[i]);
                    Partition tempParition = currentPartition;
                    currentPartition = currentPartition.NextPartition;
                    memoryLeft -= JobQueue[i].MemorySpace;
                }
            }

            if(memoryLeft != 0)
            {
                currentPartition.NextPartition = new Partition(memoryLeft);
                currentPartition = currentPartition.NextPartition;
            }

            this.lastPartition = currentPartition;
        }

        //Simulates 1 Cycle of the Main Memory. This includes updating the times of the jobs, 
        //freeing and defragmenting memory with finished jobs, and allocating the next job.
        public override void Update()
        {
            this.UpdateJobs();
            this.MergeEmptyPartition();
            this.Allocate();
        }
        //[Untested] Resets the jobs status if already allocated and (*not implemented*) time is not finished
        
        public void Reset()
        {
            foreach (Partition iPartition in MemoryBlocks)
            {
                iPartition.ResetJob();
            }
        }

        //Subtracts one in the Partition's time and frees the memory is the time is zero
        private void UpdateJobs()
        {
            Partition readPartition = this.firstPartition;
            bool hasPartitionsLeft = true;

            while (hasPartitionsLeft)
            {
                readPartition.CurrentJob.Update();
                hasPartitionsLeft = !readPartition.Equals(this.lastPartition); //lastPartition check must be done before readPartition to 
                if (readPartition.CurrentJob.TimeLeft > 0)
                {
                    readPartition = readPartition.NextPartition;
                }
                else
                {
                    readPartition.Dump(readPartition.CurrentJob.MemorySpace);
                }
            }
        }

        //Merges any adjacent empty partitions into one empty partition. 
        //It does by remembering the first empty partition, then adding the sizes of the next empty 
        //adjacent partitions. Finally, it removes the adjacent empty partitions
        private void MergeEmptyPartition()
        {
            Partition readPartition = this.firstPartition;
            bool hasPartitionsLeft = true;

            while (hasPartitionsLeft)
            {
                hasPartitionsLeft = readPartition != this.lastPartition;
                Partition firstEmptyPartition = readPartition;

                //The "hasPartionsLeft" condition has to be first otherwise it will cause a NullException
                while (hasPartitionsLeft && readPartition.CurrentJob.IsEmpty && readPartition.NextPartition.CurrentJob.IsEmpty)
                {
                    hasPartitionsLeft = readPartition.NextPartition != this.lastPartition;
                    firstEmptyPartition.CurrentJob.MemorySpace += readPartition.NextPartition.CurrentJob.MemorySpace;
                    
                    if(hasPartitionsLeft)
                    {
                        readPartition = readPartition.NextPartition;
                    }
                }

                if (hasPartitionsLeft)
                {
                    firstEmptyPartition.NextPartition = readPartition.NextPartition;
                }
                else
                {
                    this.lastPartition = firstEmptyPartition;
                    firstEmptyPartition.NextPartition = null;
                }
                
                readPartition = readPartition.NextPartition;                
            }
        }

        //This finds any empty partion, then finds a job to allocated it. Which job is selected depending
        //on the allcation mode. If the job allocated is smaller than the empty partition, another
        //empty partition is created with is the size of difference of the partition size  and job's size
        private void Allocate()
        {
           Partition readPartition = this.firstPartition;
           bool hasPartitionsLeft = true;

            while (hasPartitionsLeft)
            {
                if (readPartition.CurrentJob.IsEmpty)
                {
                    Job nextJob = FindJob(readPartition);

                    int leftoverSpace = readPartition.CurrentJob.MemorySpace - nextJob.MemorySpace;
                    readPartition.CurrentJob = nextJob;

                    if (leftoverSpace > 0)
                    {
                        Partition newEmptyPartition = new Partition(new Job(int.MaxValue, 100, leftoverSpace, true));
                        newEmptyPartition.NextPartition = readPartition.NextPartition;
                        readPartition.NextPartition = newEmptyPartition;

                        if (readPartition.Equals(this.lastPartition))
                        {
                            this.lastPartition = newEmptyPartition;
                        }
                    }
                }
                
                hasPartitionsLeft = readPartition != this.lastPartition;
                readPartition = readPartition.NextPartition;
            }
        }
    }
}