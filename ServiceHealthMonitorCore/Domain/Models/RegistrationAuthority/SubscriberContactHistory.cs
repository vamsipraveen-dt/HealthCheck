using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberContactHistory
{
    public int SubscriberContactHistoryId { get; set; }

    public string SubscriberUid { get; set; } = null!;

    public string? MobileNumber { get; set; }

    public string? EmailId { get; set; }

    public DateTime? CreatedDate { get; set; }
}
