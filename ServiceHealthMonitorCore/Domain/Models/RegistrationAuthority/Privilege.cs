using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class Privilege
{
    public int PrivilegeId { get; set; }

    public string PrivilegeServiceName { get; set; } = null!;

    public string? PrivilegeServiceDisplayName { get; set; }

    public string? Status { get; set; }

    public sbyte? IsChargeable { get; set; }

    public virtual ICollection<BeneficiaryValidity> BeneficiaryValidities { get; set; } = new List<BeneficiaryValidity>();
}
