using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;

public partial class TemporaryTable
{
    public int Id { get; set; }

    public string? IdDocNumber { get; set; }

    public string? DeviceId { get; set; }

    public string? OptionalData1 { get; set; }

    public string? DeviceInfo { get; set; }

    public string? Step1Status { get; set; }

    public string? Step1Data { get; set; }

    public string? Step2Status { get; set; }

    public string? Step2Data { get; set; }

    public string? Step3Status { get; set; }

    public string? Step3Data { get; set; }

    public string? Step4Status { get; set; }

    public string? Step4Data { get; set; }

    public string? Step5Status { get; set; }

    public string? Step5Data { get; set; }

    public int? StepCompleted { get; set; }

    public int? NextStep { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public byte[]? LivelinessVideo { get; set; }

    public string? Selfie { get; set; }
}
