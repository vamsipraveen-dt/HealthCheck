using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class AppConfig
{
    public int Id { get; set; }

    public string? OsVersion { get; set; }

    public string? LatestVersion { get; set; }

    public string? MinimumVersion { get; set; }

    public string? UpdateLink { get; set; }
}
