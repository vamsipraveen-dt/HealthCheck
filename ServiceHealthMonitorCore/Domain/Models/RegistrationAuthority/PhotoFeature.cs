using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class PhotoFeature
{
    public int Id { get; set; }

    public string SubscriberUid { get; set; } = null!;

    public byte[]? PhotoFeatures { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
