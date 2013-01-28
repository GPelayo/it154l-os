using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainMemorySimulator
{
    public class Program
    {
        static Memory currentMemory;
        static int cycle = 0;

        static void Main(string[] args)
        {
            List<Job> jobQueue = LabFixedParitionQueue();
            //List<Job> jobQueue = DynamicParitionTestQueue();

            List<Partition> partitions = LabFixedParitions();
            
            currentMemory = new FixedPartitionMemory(partitions,jobQueue, false, false);
            //currentMemory = new DynamicPartitionMemory(1000, jobQueue, false, true);
            
            Console.Out.WriteLine("Cycle: " + cycle++ + "\n");
            Display();
            Console.ReadLine();

            do
            {
                Console.Out.WriteLine("Cycle: " + cycle++ + "\n");

                currentMemory.Update();
                Display();
                Console.ReadLine();
            } while (!currentMemory.IsFinished);

            Console.Out.WriteLine("Queue Empty.");
            Console.ReadLine();
        }

        static void Display()
        {
            
            Job currentJob;
            
            foreach(Partition partition in currentMemory.MemoryBlocks)
            {
                currentJob = partition.CurrentJob;
                Console.Out.WriteLine(currentJob.Number + ": \t(" + currentJob.MemorySpace + "KB) \tT-" + partition.CurrentJob.TimeLeft);
            }

            Console.Out.WriteLine();
            
        }

        static List<Job> DynamicParitionTestQueue()
        {
            List<Job> jobQueue = new List<Job>();

            jobQueue.Add(new Job(1, 3, 250));
            jobQueue.Add(new Job(2, 4, 500));
            jobQueue.Add(new Job(3, 2, 100));
            jobQueue.Add(new Job(4, 1, 400));
            jobQueue.Add(new Job(5, 2, 300));
            jobQueue.Add(new Job(6, 3, 150));
            jobQueue.Add(new Job(7, 2, 100));
            jobQueue.Add(new Job(8, 4, 200));
            jobQueue.Add(new Job(9, 2, 400));
            jobQueue.Add(new Job(10, 1, 300));

            return jobQueue;
        }

        static List<Job> LabFixedParitionQueue()
        {
            List<Job> jobQueue = new List<Job>();

            jobQueue.Add(new Job(1, 5, 5760));
            jobQueue.Add(new Job(2, 4, 4190));
            jobQueue.Add(new Job(3, 8, 3290));
            jobQueue.Add(new Job(4, 2, 2030));
            jobQueue.Add(new Job(5, 2, 2550));
            jobQueue.Add(new Job(6, 6, 6990));
            jobQueue.Add(new Job(7, 8, 8940));
            jobQueue.Add(new Job(8, 10, 740));
            jobQueue.Add(new Job(9, 7, 3930));
            jobQueue.Add(new Job(10, 6, 6890));
            jobQueue.Add(new Job(11, 5, 6580));
            jobQueue.Add(new Job(12, 8, 3280));
            jobQueue.Add(new Job(13, 9, 9140));
            jobQueue.Add(new Job(14, 10, 420));
            jobQueue.Add(new Job(15, 10, 220));
            jobQueue.Add(new Job(16, 7, 7540));
            jobQueue.Add(new Job(17, 3, 3210));
            jobQueue.Add(new Job(18, 1, 1380));
            jobQueue.Add(new Job(19, 9, 9850));
            jobQueue.Add(new Job(20, 3, 3610));
            jobQueue.Add(new Job(21, 7, 7540));
            jobQueue.Add(new Job(22, 2, 2710));
            jobQueue.Add(new Job(23, 8, 8390));
            jobQueue.Add(new Job(24, 5, 5950));
            jobQueue.Add(new Job(25, 10, 1760));
            return jobQueue;
        }

        static List<Partition> LabFixedParitions()
        {
            List<Partition> partition = new List<Partition>();

            partition.Add(new FixedPartition(9500));
            partition.Add(new FixedPartition(7000));
            partition.Add(new FixedPartition(4500));
            partition.Add(new FixedPartition(8500));
            partition.Add(new FixedPartition(3000));
            partition.Add(new FixedPartition(9000));
            partition.Add(new FixedPartition(1000));
            partition.Add(new FixedPartition(5500));
            partition.Add(new FixedPartition(1500));
            partition.Add(new FixedPartition(500));

            return partition;
        }
    }
}
