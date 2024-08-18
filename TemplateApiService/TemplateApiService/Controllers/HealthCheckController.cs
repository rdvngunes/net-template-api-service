using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TemplateApiService.Common;
using TemplateApiService.Common.Enums;
using TemplateApiService.Common.RestClient;
using TemplateApiService.ViewModels.HealthCheck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace TemplateApiService.Controllers
{

    [Route(@"api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly HealthCheckService _healthCheckService;
        private readonly TemplateConfiguration _config;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="healthCheckService"></param>
        /// <param name="configuration"></param>
        public HealthCheckController(HealthCheckService healthCheckService, TemplateConfiguration configuration)
        {
            _healthCheckService = healthCheckService;
            _config = configuration;
        }

        /// <summary>
        /// Request information regarding system health
        /// </summary>
        /// <response code="200">System health statuses returned.</response>
        [HttpGet]
        [Route("/health")]
        [ProducesResponseType(typeof(HealthCheckResultViewItem), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
           using (var timedTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
            {
                var healthCheckResult = await _healthCheckService.CheckHealthAsync(timedTokenSource.Token);

                var results = new List<HealthCheckItem>();

                foreach (var entry in healthCheckResult.Entries)
                {
                    results.Add(new HealthCheckItem { Resource = entry.Value.Tags.FirstOrDefault(), Status = entry.Value.Status.ToString() });
                }

                results.Add(new HealthCheckItem { Resource = $"SORA Service v{_config.CurrentApiVersion}", Status = HealthStatus.Healthy.ToString() });

                ApiRestResponseResult healthCheckResponse = new ApiRestResponseResult();
                HealthCheckResultViewItem healthItem = new HealthCheckResultViewItem { Status = healthCheckResult.Status.ToString(), Result = results };

                healthItem = SetServerUtilizations(healthItem);
                healthCheckResponse.Data = healthItem;

                if (healthCheckResult.Status == HealthStatus.Healthy)
                {
                    return new OkObjectResult(healthCheckResponse);
                }
                else
                {
                    healthCheckResponse.StatusCode = StatusCodes.Status424FailedDependency;
                    healthCheckResponse.Status = EnumHttpStatusCode.error;
                    List<string> unhealthyMessage = new List<string>();

                    for (int i = 0; i < results.Count; i++)
                    {
                        if (results[i].Status != "Healthy")
                        {
                            unhealthyMessage.Add(results[i].Resource + " is Unhealthy.");
                        }
                    }
                    healthCheckResponse.Error = new ErrorViewModel(unhealthyMessage);

                    return healthCheckResponse.Adapt<ObjectResult>();
                }

            }
        }
        private HealthCheckResultViewItem SetServerUtilizations(HealthCheckResultViewItem healthchekcItem)
        {
            var client = new MemoryMetricsClient();
            var memoryMetrics = client.GetMetrics();
            var discMetrics = DiskUsages();

            healthchekcItem.Ip = GetLocalIPAddress();
            healthchekcItem.ServiceName = Assembly.GetEntryAssembly().GetName().Name;
            healthchekcItem.TotalMemory = (int)(memoryMetrics.Total / 1024) + " gb";
            healthchekcItem.MemoryUsage = (int)(100 * memoryMetrics.Used / memoryMetrics.Total) + " %";

            if (discMetrics != null)
            {
                healthchekcItem.DiskAllocated = (int)(discMetrics.TotalSize / (1024 * 1024)) + " mb"; ;
                healthchekcItem.DiskUsage = (int)(100 * (discMetrics.TotalSize - discMetrics.TotalFreeSpace) / discMetrics.TotalSize) + " %"; ;
            }
            healthchekcItem.CpuUtilization = CpuUtilization();

            return healthchekcItem;
        }
        private string GetLocalIPAddress()
        {
            return Dns.GetHostEntry(Dns.GetHostName())
        .AddressList
        .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        .ToString();
        }
        private string CpuUtilization()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var startTime = DateTime.UtcNow;
                var startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
                var stopWatch = new Stopwatch();
                // Start watching CPU
                stopWatch.Start();

                System.Threading.Thread.Sleep(1000);

                // Stop watching to meansure
                stopWatch.Stop();
                var endTime = DateTime.UtcNow;
                var endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;

                var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
                var totalMsPassed = (endTime - startTime).TotalMilliseconds;
                var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);

                return (int)cpuUsageTotal * 100 + " %";
            }
            else
            {
                var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuCounter.NextValue();
                System.Threading.Thread.Sleep(1000);
                return (int)cpuCounter.NextValue() + " %";
            }
        }
        private DriveInfo DiskUsages()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            var firstDriver = allDrives.FirstOrDefault();
            if (firstDriver.IsReady == true)
            {
                return firstDriver;
            }
            return null;
        }
    }
}
