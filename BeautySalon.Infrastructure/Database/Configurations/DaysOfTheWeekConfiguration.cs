﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using BeautySalon.Infrastructure;
using BeautySalon.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace BeautySalon.Infrastructure.Database.Configurations
{
    public partial class DaysOfTheWeekConfiguration : IEntityTypeConfiguration<DaysOfTheWeek>
    {
        public void Configure(EntityTypeBuilder<DaysOfTheWeek> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Days_of___3213E83F4627725C");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<DaysOfTheWeek> entity);
    }
}