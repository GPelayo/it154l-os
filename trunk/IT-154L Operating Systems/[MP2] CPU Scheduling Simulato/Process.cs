using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_Scheduling_Simulator
{
    public enum ProcessStatus
    {
        Hold, Ready, Running, Waiting, Finished
    }

    public enum ProcessType
    {
        N, NPR, PR
    }

    public class Process
    {
        public static Process Empty = new Process();

        private int timeFinished;
        private int timeStarted;
        private int timeElapsed;
        private int initialCPUCycle;
        private int currentCPUCycle;
        private ProcessStatus status;

        public int JobNumber { get; set; }
        public int ArrivalTime { get; set; }
        public int RoundQuotient { get; set; }
        public int InitialCPUCycle { get { return initialCPUCycle; } }
        public int CurrentCPUCycle { get { return currentCPUCycle; } }
        public ProcessType Type { get; set; }
        public ProcessStatus Status
        {
            set
            {
                status = value;

                if (!Status.Equals(ProcessStatus.Hold))
                {
                    timeStarted = timeElapsed;
                }
                else if (Status.Equals(ProcessStatus.Finished))
                {
                    timeFinished = timeElapsed;
                }
            }
            get
            {
                return status;
            }
        }
        public int TurnaroundTime
        {
            get
            {
                return 0 - 0;
            }
        }
        public int WaitingTime
        {
            get
            {
                return 0 - 0;
            }
        }
        public int ResponseTime
        {
            get
            {
                return 0 - 0;
            }
        }

        private Process()
        {
            this.JobNumber = Int16.MaxValue;
            this.status = ProcessStatus.Finished;
            this.Type = ProcessType.N;
        }

        public Process(int jobNumber, int arrivalTime, int CPUCycle, ProcessType type)
        {
            timeElapsed = 0;
            currentCPUCycle = CPUCycle;
            this.JobNumber = jobNumber;
            this.ArrivalTime = arrivalTime;
            this.initialCPUCycle = CPUCycle;
            this.Type = type;
            this.Status = ProcessStatus.Hold;
        }

        public void Update()
        {
            if (Status.Equals(ProcessStatus.Running))
            {
                currentCPUCycle--;
            }

            timeElapsed++;
        }
    }
}
