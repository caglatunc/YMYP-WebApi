
using Microsoft.EntityFrameworkCore;
using Portfolio.WebApi.Models;

namespace Portfolio.WebApi.Context;

public class AppDbContext :DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    optionsBuilder.UseSqlServer("Data Source=CAGLA\\SQLEXPRESS;Initial Catalog=YMYP_Portfolio;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
  }
    public DbSet<MyInformation> MyInformations { get; set; }
    public DbSet<MySkill> MySkills { get; set; }

}
