using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberStatus
{
    public int SubscriberStatusId { get; set; }

    public string SubscriberUid { get; set; } = null!;

    public string? SubscriberStatus1 { get; set; }

    public string? SubscriberStatusDescription { get; set; }

    public string? OtpVerifiedStatus { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Subscriber SubscriberU { get; set; } = null!;
}
