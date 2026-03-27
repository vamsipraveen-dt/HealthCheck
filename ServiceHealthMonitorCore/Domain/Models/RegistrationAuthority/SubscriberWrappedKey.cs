using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberWrappedKey
{
    public string CertificateSerialNumber { get; set; } = null!;

    public string WrappedKey { get; set; } = null!;
}
