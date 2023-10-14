using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static PRN221_ProjectDemo.Models.StEmployeeInfo;

namespace PRN221_ProjectDemo.Models;

public partial class Prn221ProjectContext : DbContext
{
    public Prn221ProjectContext()
    {
    }

    public Prn221ProjectContext(DbContextOptions<Prn221ProjectContext> options)
        : base(options)
    {
    }
    public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }

    public virtual DbSet<Allowance> Allowances { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<JobLevel> JobLevels { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkHour> WorkHours { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PRN221_Project;User Id=sa;Password=123; TrustServerCertificate=true; Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allowance>(entity =>
        {
            entity.HasKey(e => e.AllowanceId).HasName("PK__Allowanc__7B12D0419ABB4705");

            entity.ToTable("Allowance");

            entity.Property(e => e.AllowanceId)
                .ValueGeneratedNever()
                .HasColumnName("AllowanceID");
            entity.Property(e => e.AllowanceAmount).HasColumnType("money");
            entity.Property(e => e.AllowanceName).HasMaxLength(200);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDE6DD23A8");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(10)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentDuty).HasMaxLength(500);
            entity.Property(e => e.DepartmentName).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(300);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF14BA1639D");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.BeginDate).HasColumnType("date");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(10)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(500);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.JobLevelId).HasColumnName("JobLevelID");
            entity.Property(e => e.LastName).HasMaxLength(500);
            entity.Property(e => e.PhoneNumber).HasMaxLength(25);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Employee__Depart__2B3F6F97");

            entity.HasOne(d => d.EmployeeNavigation).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_User");

            entity.HasOne(d => d.JobLevel).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobLevelId)
                .HasConstraintName("FK__Employee__JobLev__2C3393D0");
        });

        modelBuilder.Entity<JobLevel>(entity =>
        {
            entity.HasKey(e => e.JobLevelId).HasName("PK__JobLevel__7594C84C375346E9");

            entity.ToTable("JobLevel");

            entity.Property(e => e.JobLevelId)
                .ValueGeneratedNever()
                .HasColumnName("JobLevelID");
            entity.Property(e => e.AllowanceId).HasColumnName("AllowanceID");
            entity.Property(e => e.SalaryPerHour).HasColumnType("money");

            entity.HasOne(d => d.Allowance).WithMany(p => p.JobLevels)
                .HasForeignKey(d => d.AllowanceId)
                .HasConstraintName("FK__JobLevel__Allowa__286302EC");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.SalaryPeriod }).HasName("PK__Payments__6DFD7B9E62C483BC");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.SalaryPeriod).HasColumnType("date");
            entity.Property(e => e.AmountTotal).HasColumnType("money");
            entity.Property(e => e.OtherPayment).HasColumnType("money");
            entity.Property(e => e.TotalHours).HasDefaultValueSql("((0))");
            entity.Property(e => e.TotalPayments).HasColumnType("money");

            entity.HasOne(d => d.Employee).WithMany(p => p.Payments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Employ__34C8D9D1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__User__7AD04FF12AB40F87");

            entity.ToTable("User");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<WorkHour>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.WorkDay }).HasName("PK__WorkHour__A7F4BFBFB5696690");

            entity.ToTable("WorkHour");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.WorkDay).HasColumnType("date");
            entity.Property(e => e.Coefficient).HasDefaultValueSql("((1))");
            entity.Property(e => e.TimeEnd).HasColumnType("datetime");
            entity.Property(e => e.TimeStart).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.WorkHours)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkHour__Employ__30F848ED");
        });

        modelBuilder.Entity<StEmployeeInfo.EmployeeInfo>().HasKey(e => e.EmployeeId); // Thay EmployeeId bằng tên trường khóa chính thực tế
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
