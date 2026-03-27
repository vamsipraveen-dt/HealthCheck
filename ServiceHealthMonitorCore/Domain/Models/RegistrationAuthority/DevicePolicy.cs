using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class DevicePolicy
{
    public int Id { get; set; }

    public int? DeviceChangePolicyHour { get; set; }
}
