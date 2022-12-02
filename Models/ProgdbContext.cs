using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace PROG_POE_Part3.Models;

public partial class ProgdbContext : DbContext
{
    public ProgdbContext()
    {
    }

    public ProgdbContext(DbContextOptions<ProgdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;PersistSecurityInfo=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleCode).HasName("PK__Modules__4BE7616F3459E9F6");

            entity.Property(e => e.ModuleCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Module_Code");
            entity.Property(e => e.ClassHours)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModuleCredits)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Module_Credits");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Module_Name");
            entity.Property(e => e.SelfStudyCompleted)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Self_Study_Completed");
            entity.Property(e => e.SelfStudyTotal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Self_Study_Total");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Modules)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK__Modules__Usernam__6FE99F9F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__Users__536C85E54BC51F99");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
            //entity.Property(e => e.HashedPassword)
            //    .HasMaxLength(100)
            //    .IsUnicode(false)
            //    .HasColumnName("hashedPassword");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    //SqlConnection con = new SqlConnection("Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    //public string AddEmployeeRecord(Module newModules)
    //{
    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand("sp_Employee_Add", con);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@Module_Code", newModules.ModuleCode);
    //        cmd.Parameters.AddWithValue("@Module_Name", newModules.ModuleName);
    //        cmd.Parameters.AddWithValue("@Module_Credits", newModules.ModuleCredits);
    //        cmd.Parameters.AddWithValue("@Self_Study_Total", newModules.SelfStudyTotal);
    //        cmd.Parameters.AddWithValue("@Self_Study_Completed", newModules.SelfStudyCompleted);
    //        cmd.Parameters.AddWithValue("@Username", newModules.Username);
    //        con.Open();
    //        cmd.ExecuteNonQuery();
    //        con.Close();
    //        return ("Data save Successfully");
    //    }
    //    catch (Exception ex)
    //    {
    //        if (con.State == ConnectionState.Open)
    //        {
    //            con.Close();
    //        }
    //        return (ex.Message);
    //    }
    //}
}
