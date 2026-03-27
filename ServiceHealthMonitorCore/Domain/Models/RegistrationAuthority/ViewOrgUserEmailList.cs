using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class ViewOrgUserEmailList
{
    public string? OrgEmailsList { get; set; }

    public string? SubscriberUid { get; set; }
}
