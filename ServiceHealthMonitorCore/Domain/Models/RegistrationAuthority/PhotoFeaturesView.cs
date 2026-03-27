using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class PhotoFeaturesView
{
    public int PhotoFeaturesId { get; set; }

    public byte[]? PhotoFeatures { get; set; }
}
