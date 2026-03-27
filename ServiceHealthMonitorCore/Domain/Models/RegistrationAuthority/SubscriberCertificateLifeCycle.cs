using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberCertificateLifeCycle
{
    public int SubscriberCertificateLifeCycleId { get; set; }

    public string CertificateSerialNumber { get; set; } = null!;

    public string CertificateStatus { get; set; } = null!;

    public string CertificateType { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? RevocationReason { get; set; }

    public string SubscriberUid { get; set; } = null!;
}
