using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberDevice
{
    public int SubscriberDeviceId { get; set; }

    public string? SubscriberUid { get; set; }

    public string? DeviceUid { get; set; }

    public string? DeviceStatus { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Subscriber? SubscriberU { get; set; }
}
