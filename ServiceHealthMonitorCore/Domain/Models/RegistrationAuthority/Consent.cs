using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class Consent
{
    public int ConsentId { get; set; }

    public string? Consent1 { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? ConsentType { get; set; }

    public string? Status { get; set; }

    public string? PrivacyConsent { get; set; }
}
