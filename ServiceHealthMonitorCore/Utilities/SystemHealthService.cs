using ServiceHealthMonitorCore.Domain.Services.Communication;
using ServiceHealthMonitorCore.DTOs;

namespace ServerHealthMonitor.Services
{
    public class SystemHealthService
    {
        public async Task<ServiceResult> GetAll()
        {
            try
            {
                var ram = GetRamUsage();
                var disk = GetDiskUsage();
                var cpu = await GetCpuUsageAsync();

                var response = new SystemHealthDto
                {
                    Machine = Environment.MachineName,

                    Cpu = new SystemHealthDto.CpuInfo
                    {
                        UsagePercent = cpu
                    },

                    Ram = new SystemHealthDto.RamInfo
                    {
                        TotalGB = ram.totalGb,
                        UsedGB = ram.usedGb,
                        UsagePercent = ram.percent
                    },

                    Disk = new SystemHealthDto.DiskInfo
                    {
                        TotalGB = disk.totalGb,
                        UsedGB = disk.usedGb,
                        UsagePercent = disk.percent
                    }
                };

                return new ServiceResult(response, "Successfully recieved Machine Data");
            }
            catch (Exception ex)
            {
                return new ServiceResult("An error occurred while getting system health data: " + ex.Message);
            }

        }

        private (double totalGb, double usedGb, double percent) GetRamUsage()
        {
            var memInfo = File.ReadAllLines("/proc/meminfo");

            double totalKb = GetValue(memInfo, "MemTotal");
            double availableKb = GetValue(memInfo, "MemAvailable");

            double usedKb = totalKb - availableKb;

            double totalGb = totalKb / 1024 / 1024;
            double usedGb = usedKb / 1024 / 1024;
            double percent = (usedKb / totalKb) * 100;

            return (Math.Round(totalGb, 2), Math.Round(usedGb, 2), Math.Round(percent, 2));
        }

        private double GetValue(string[] lines, string key)
        {
            var line = lines.First(x => x.StartsWith(key));
            var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return double.Parse(parts[1]); // value in KB
        }

        private (double totalGb, double usedGb, double percent) GetDiskUsage()
        {
            var root = DriveInfo.GetDrives()
                .First(d => d.Name == "/" || d.RootDirectory.FullName == "/");

            double totalGb = root.TotalSize / 1024.0 / 1024 / 1024;
            double freeGb = root.AvailableFreeSpace / 1024.0 / 1024 / 1024;
            double usedGb = totalGb - freeGb;
            double percent = (usedGb / totalGb) * 100;

            return (Math.Round(totalGb, 2), Math.Round(usedGb, 2), Math.Round(percent, 2));
        }

        private async Task<double> GetCpuUsageAsync()
        {
            var first = ReadCpuStat();
            await Task.Delay(500);
            var second = ReadCpuStat();

            var idle = second.idle - first.idle;
            var total = second.total - first.total;

            var cpuUsage = 100.0 * (1.0 - ((double)idle / total));
            return Math.Round(cpuUsage, 2);
        }

        private (long idle, long total) ReadCpuStat()
        {
            var cpuLine = File.ReadLines("/proc/stat").First();
            var parts = cpuLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            // user nice system idle iowait irq softirq steal
            long user = long.Parse(parts[1]);
            long nice = long.Parse(parts[2]);
            long system = long.Parse(parts[3]);
            long idle = long.Parse(parts[4]);
            long iowait = long.Parse(parts[5]);
            long irq = long.Parse(parts[6]);
            long softirq = long.Parse(parts[7]);
            long steal = parts.Length > 8 ? long.Parse(parts[8]) : 0;

            long idleAll = idle + iowait;
            long systemAll = system + irq + softirq;
            long total = user + nice + systemAll + idleAll + steal;

            return (idleAll, total);
        }
    }
}
