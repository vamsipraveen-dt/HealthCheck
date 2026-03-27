using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberView
{
    public string SubscriberUid { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? IdDocType { get; set; }

    public string? IdDocNumber { get; set; }

    public string DisplayName { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? OrgEmailsList { get; set; }

    public string CertificateStatus { get; set; } = null!;

    public string? SubscriberStatus { get; set; }

    public string? FcmToken { get; set; }

    public string? Loa { get; set; }

    public string? Gender { get; set; }

    public string? DateOfExpiry { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? SelfieUri { get; set; }

    public string Country { get; set; } = null!;
}
