using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberCertificate
{
    public string CertificateSerialNumber { get; set; } = null!;

    public string CertificateData { get; set; } = null!;

    public DateTime CerificateExpiryDate { get; set; }

    public DateTime CertificateIssueDate { get; set; }

    public string CertificateStatus { get; set; } = null!;

    public string CertificateType { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string PkiKeyId { get; set; } = null!;

    public string? Remarks { get; set; }

    public string SubscriberUid { get; set; } = null!;

    public DateTime? UpdatedDate { get; set; }
}
