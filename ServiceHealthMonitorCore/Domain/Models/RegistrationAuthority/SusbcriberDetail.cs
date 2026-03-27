using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SusbcriberDetail
{
    public string SubscriberUid { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? IdDocType { get; set; }

    public string? IdDocNumber { get; set; }

    public string MobileNumber { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string? OsName { get; set; }

    public string? OsVersion { get; set; }

    public string? AppVersion { get; set; }

    public string? DeviceInfo { get; set; }

    public string? SubscriberStatus { get; set; }

    public string? DeviceStatus { get; set; }

    public string? DeviceUid { get; set; }
}
