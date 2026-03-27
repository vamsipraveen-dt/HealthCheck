using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class OrgClientAppConfig
{
    public int Id { get; set; }

    public string? OrgId { get; set; }

    public string? AppId { get; set; }

    public string? ConfigValue { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
