﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMPDB.Models;

public partial class EmployeeDBContext : DbContext
{
    public EmployeeDBContext()
    {
    }

    public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-ND5BE27\\MSSQLSERVER01;Initial Catalog=EmployeeDB;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.DepartmentAbbr)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentName)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.HasIndex(e => e.Departmentid, "IX_Employee_Departmentid");

            entity.Property(e => e.EmployeeName)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeNumber)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.GrossSalary).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.NetSalary).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasForeignKey(d => d.Departmentid);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}