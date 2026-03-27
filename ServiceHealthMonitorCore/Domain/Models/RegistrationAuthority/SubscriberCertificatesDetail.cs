using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberCertificatesDetail
{
    public string SubscriberUid { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? IdDocType { get; set; }

    public string? IdDocNumber { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? OnBoardingMethod { get; set; }

    public DateTime CerificateExpiryDate { get; set; }

    public DateTime CertificateIssueDate { get; set; }

    public string CertificateSerialNumber { get; set; } = null!;

    public string CertificateStatus { get; set; } = null!;

    public string CertificateType { get; set; } = null!;
}
