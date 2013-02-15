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
        private int currentCPUCycle;
        private ProcessStatus status;
        private bool alreadyStarted;
        public int TimeElapsed { get; set; }
        public int JobNumber { get; set; }
        public int ArrivalTime { get; set; }
        public int RoundQuotient { get; set; }
        public int InitialCPUCycle { get; set; }
        public int CurrentCPUCycle { get { return currentCPUCycle; } }
        public ProcessType Type { get; set; }
        public ProcessStatus Status
        {
            set
            {
                status = value;

                if (status.Equals(ProcessStatus.Running) && !alreadyStarted)
                {                    
                    alreadyStarted = true;
                    timeStarted = TimeElapsed;
                }

                if (status.Equals(ProcessStatus.Finished))
                {
                    timeFinished = TimeElapsed;
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
                return timeFinished - ArrivalTime;
            }
        }
        public int WaitingTime
        {
            get
            {
                return TurnaroundTime - this.InitialCPUCycle;
            }
        }
        public int ResponseTime
        {
            get
            {
                return timeStarted - this.ArrivalTime;
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
            alreadyStarted = false;
            timeStarted = 0;
            timeFinished = 0;
            this.currentCPUCycle = CPUCycle;
            this.JobNumber = jobNumber;
            this.ArrivalTime = arrivalTime;
            this.InitialCPUCycle = CPUCycle;
            this.Type = type;
            this.Status = ProcessStatus.Hold;
        }

        public void Reset()
        {
            this.currentCPUCycle = this.InitialCPUCycle;
            this.Status = ProcessStatus.Hold;
            alreadyStarted = false;
            timeFinished = 0;
            timeStarted = 0;
        }

        public void Update(int currentTime)
        {
            if (Status.Equals(ProcessStatus.Running))
            {
                currentCPUCycle--;
            }

            TimeElapsed = currentTime;
        }
    }
}
