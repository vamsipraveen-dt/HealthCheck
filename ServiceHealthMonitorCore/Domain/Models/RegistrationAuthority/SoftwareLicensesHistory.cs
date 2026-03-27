using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SoftwareLicensesHistory
{
    public int Id { get; set; }

    public string? Ouid { get; set; }

    public string? SoftwareName { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public string? LicenseInfo { get; set; }

    public DateTime? IssuedOn { get; set; }

    public DateTime? ValidUpto { get; set; }

    public string? LicenseType { get; set; }
}
