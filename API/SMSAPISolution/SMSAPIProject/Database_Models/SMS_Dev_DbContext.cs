using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SMSAPIProject.Database_Models
{
    public partial class SMS_Dev_DbContext : DbContext
    {
        public SMS_Dev_DbContext()
        {
        }

        public SMS_Dev_DbContext(DbContextOptions<SMS_Dev_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MstClass> MstClasses { get; set; } = null!;
        public virtual DbSet<MstRole> MstRoles { get; set; } = null!;
        public virtual DbSet<MstSalutation> MstSalutations { get; set; } = null!;
        public virtual DbSet<MstSection> MstSections { get; set; } = null!;
        public virtual DbSet<StudentAttendenceDetail> StudentAttendenceDetails { get; set; } = null!;
        public virtual DbSet<StudentDetail> StudentDetails { get; set; } = null!;
        public virtual DbSet<TeacherAttendenceDetail> TeacherAttendenceDetails { get; set; } = null!;
        public virtual DbSet<TeacherDetail> TeacherDetails { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLExpress;Database=SMS_Dev_Db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstClass>(entity =>
            {
                entity.ToTable("mst_classes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("class_name");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("is_active");
            });

            modelBuilder.Entity<MstRole>(entity =>
            {
                entity.ToTable("mst_roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<MstSalutation>(entity =>
            {
                entity.ToTable("mst_salutations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.SalutationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("salutation_name");
            });

            modelBuilder.Entity<MstSection>(entity =>
            {
                entity.ToTable("mst_sections");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.SectionName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("section_name");
            });

            modelBuilder.Entity<StudentAttendenceDetail>(entity =>
            {
                entity.ToTable("student_attendence_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttendenceDate)
                    .HasColumnType("date")
                    .HasColumnName("attendence_date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsAbsent)
                    .HasColumnName("is_absent")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsHalfDayPresent)
                    .HasColumnName("is_half_day_present")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsLate)
                    .HasColumnName("is_late")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsOnLeave)
                    .HasColumnName("is_on_leave")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPresent)
                    .HasColumnName("is_present")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.Session)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("session");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentAttendenceDetails)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__student_a__stude__656C112C");
            });

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.ToTable("student_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Class)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("class");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EnrollmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("enrollment_date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.GradeLevel).HasColumnName("grade_level");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Photo)
                    .HasColumnType("text")
                    .HasColumnName("photo");

                entity.Property(e => e.RollNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("roll_no");

                entity.Property(e => e.Section)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("section");

                entity.Property(e => e.Session)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("session");
            });

            modelBuilder.Entity<TeacherAttendenceDetail>(entity =>
            {
                entity.ToTable("teacher_attendence_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttendenceDate)
                    .HasColumnType("date")
                    .HasColumnName("attendence_date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InTime).HasColumnName("in_time");

                entity.Property(e => e.IsAbsent)
                    .HasColumnName("is_absent")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsHalfDayPresent)
                    .HasColumnName("is_half_day_present")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsLate)
                    .HasColumnName("is_late")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsOnLeave)
                    .HasColumnName("is_on_leave")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPresent)
                    .HasColumnName("is_present")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.OutTime).HasColumnName("out_time");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherAttendenceDetails)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__teacher_a__teach__6E01572D");
            });

            modelBuilder.Entity<TeacherDetail>(entity =>
            {
                entity.ToTable("teacher_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Department)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("department");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ExperienceYears).HasColumnName("experience_years");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Photo)
                    .HasColumnType("text")
                    .HasColumnName("photo");

                entity.Property(e => e.Position)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.Qualifications)
                    .HasColumnType("text")
                    .HasColumnName("qualifications");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("salary");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.ToTable("user_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Photo)
                    .HasColumnType("text")
                    .HasColumnName("photo");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.SalutationId).HasColumnName("salutation_id");

                entity.Property(e => e.Token)
                    .HasColumnType("text")
                    .HasColumnName("token");

                entity.Property(e => e.TokenExpiry)
                    .HasColumnType("datetime")
                    .HasColumnName("token_expiry");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
