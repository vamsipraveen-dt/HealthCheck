using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class ViewClientApp
{
    public string ClientId { get; set; } = null!;

    public string? ApplicationName { get; set; }

    public string? OrganizationUid { get; set; }

    public string? OrgName { get; set; }

    public bool? EnablePostPaidOption { get; set; }

    public string? OrganizationStatus { get; set; }

    public string? ClientAppStatus { get; set; }
}
