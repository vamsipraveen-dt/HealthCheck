using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.DTOs
{
    public class SystemHealthDto
    {
        public string Machine { get; set; } = string.Empty;
        public CpuInfo Cpu { get; set; } = new();
        public RamInfo Ram { get; set; } = new();
        public DiskInfo Disk { get; set; } = new();

        public class CpuInfo
        {
            public double UsagePercent { get; set; }
        }

        public class RamInfo
        {
            public double TotalGB { get; set; }
            public double UsedGB { get; set; }
            public double UsagePercent { get; set; }
        }

        public class DiskInfo
        {
            public double TotalGB { get; set; }
            public double UsedGB { get; set; }
            public double UsagePercent { get; set; }
        }
    }
}
