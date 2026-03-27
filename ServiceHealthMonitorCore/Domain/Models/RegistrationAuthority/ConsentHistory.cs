using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class ConsentHistory
{
    public int Id { get; set; }

    public int ConsentId { get; set; }

    public string Consent { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? OptionalTermsAndConditions { get; set; }

    public string? OptionalDataAndPrivacy { get; set; }

    public string ConsentType { get; set; } = null!;

    public sbyte ConsentRequired { get; set; }

    public string PrivacyConsent { get; set; } = null!;
}
