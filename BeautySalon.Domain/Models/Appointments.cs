﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Infrastructure;

public partial class Appointments
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("client_id")]
    public int ClientId { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("service_id")]
    public int ServiceId { get; set; }

    [Column("date_time", TypeName = "datetime")]
    public DateTime DateTime { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("Appointments")]
    public virtual Clients Client { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("Appointments")]
    public virtual Employees Employee { get; set; } = null!;

    [InverseProperty("Appointment")]
    public virtual ICollection<Payments> Payments { get; set; } = new List<Payments>();

    [ForeignKey("ServiceId")]
    [InverseProperty("Appointments")]
    public virtual Services Service { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("Appointments")]
    public virtual Status Status { get; set; } = null!;
}