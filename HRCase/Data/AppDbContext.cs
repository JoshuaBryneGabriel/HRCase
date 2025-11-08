namespace HRCase.Data
{
    using HRCase.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Reflection.Emit;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Added DbSets for the imported tables
        public DbSet<TblEmpLog> TblEmpLogs { get; set; }
        public DbSet<ENTblData> ENTblDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Map ENTblData.EmpId (string) to TblEmpLog.EmpId (string) as the principal key
            modelBuilder.Entity<TblEmpLog>()
                .HasMany(t => t.DisciplinaryCases)
                .WithOne(d => d.Employee)
                .HasForeignKey(d => d.EmpId)
                .HasPrincipalKey(t => t.EmpId);

            // Consider adding additional configurations here based on your models
            // For example, relationships between DisciplinaryCase, Employee, and Approval
        }
    }
}