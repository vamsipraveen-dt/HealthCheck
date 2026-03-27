using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class SubscriberCompleteDetail
{
    public string SubscriberUid { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? SubscriberType { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? IdDocType { get; set; }

    public string? IdDocNumber { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string CertificateStatus { get; set; } = null!;

    public string? DeviceStatus { get; set; }

    public string? SubscriberStatus { get; set; }

    public DateTime? DeviceRegistrationTime { get; set; }

    public DateTime? CerificateExpiryDate { get; set; }

    public DateTime? CertificateIssueDate { get; set; }

    public DateTime? SignPinSetDate { get; set; }

    public DateTime? AuthPinSetDate { get; set; }

    public string? SelfieUri { get; set; }

    public string? SelfieThumbnailUri { get; set; }

    public DateTime? OnBoardingTime { get; set; }

    public string? OnBoardingMethod { get; set; }

    public string? LevelOfAssurance { get; set; }

    public string MobileNumber { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string? GeoLocation { get; set; }

    public string? Gender { get; set; }

    public DateTime? RevocationDate { get; set; }

    public string? RevocationReason { get; set; }

    public string CertificateSerialNumber { get; set; } = null!;

    public string? VideoUrl { get; set; }

    public string? VideoType { get; set; }
}
