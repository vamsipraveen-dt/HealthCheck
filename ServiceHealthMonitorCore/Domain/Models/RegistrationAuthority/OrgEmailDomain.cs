using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class OrgEmailDomain
{
    public int OrgDomainId { get; set; }

    public string OrganizationUid { get; set; } = null!;

    public string? EmailDomain { get; set; }

    public sbyte Status { get; set; }

    public string? CreatedOn { get; set; }

    public string? UpdatedOn { get; set; }

    public virtual OrganizationDetail OrganizationU { get; set; } = null!;
}
