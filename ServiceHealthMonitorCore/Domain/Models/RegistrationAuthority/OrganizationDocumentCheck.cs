using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class OrganizationDocumentCheck
{
    public int OrganizationDocCheckId { get; set; }

    public string? OrganizationUid { get; set; }

    public string? DocumentCheckBox { get; set; }

    public virtual OrganizationDetail? OrganizationU { get; set; }
}
