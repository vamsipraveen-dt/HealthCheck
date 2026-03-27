using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class BeneficiaryValidity
{
    public int Id { get; set; }

    public int BeneficiaryId { get; set; }

    public int? PrivilegeServiceId { get; set; }

    public sbyte? ValidityApplicable { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidUpto { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual Beneficiary Beneficiary { get; set; } = null!;

    public virtual Privilege? PrivilegeService { get; set; }
}
