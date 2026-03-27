using System;
using System.Collections.Generic;

namespace ServiceHealthMonitorCore.Domain.Models.ServiceHealth;

public partial class ServiceHistory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string History { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
