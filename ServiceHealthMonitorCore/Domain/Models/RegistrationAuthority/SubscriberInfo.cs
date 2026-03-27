using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberInfo
{
    public string SubscriberUid { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string? SubscriberStatus { get; set; }

    public string Email { get; set; } = null!;

    public string? FcmToken { get; set; }
}
