using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class Subscriber
{
    public int SubscriberId { get; set; }

    public string SubscriberUid { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? IdDocType { get; set; }

    public string? IdDocNumber { get; set; }

    public string? NationalId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? OsName { get; set; }

    public string? OsVersion { get; set; }

    public string? AppVersion { get; set; }

    public string? DeviceInfo { get; set; }

    public virtual ICollection<SubscriberDevice> SubscriberDevices { get; set; } = new List<SubscriberDevice>();

    public virtual ICollection<SubscriberDevicesHistory> SubscriberDevicesHistories { get; set; } = new List<SubscriberDevicesHistory>();

    public virtual SubscriberFcmToken? SubscriberFcmToken { get; set; }

    public virtual ICollection<SubscriberOnboardingDatum> SubscriberOnboardingData { get; set; } = new List<SubscriberOnboardingDatum>();

    public virtual SubscriberStatus? SubscriberStatus { get; set; }
}
