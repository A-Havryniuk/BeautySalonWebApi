﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Infrastructure;

[Table("Days_of_the_week")]
public partial class DaysOfTheWeek
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Name { get; set; }

    [InverseProperty("DayOfTheWeek")]
    public virtual ICollection<EmployeeSchedule> EmployeeSchedule { get; set; } = new List<EmployeeSchedule>();
}