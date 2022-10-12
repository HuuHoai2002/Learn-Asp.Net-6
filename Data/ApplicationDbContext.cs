using Microsoft.EntityFrameworkCore;

using Learn_Asp.Net_6.Models;

namespace Learn_Asp.Net_6.Data;

/**
  * DbContext là một lớp cơ sở dữ liệu được sử dụng để truy cập và thao tác với cơ sở dữ liệu.
  * DbContext là một lớp trừu tượng, nó cung cấp các phương thức để thực hiện các thao tác với cơ sở dữ liệu.
 */
public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {

  }

  // DbSet là một tập hợp các đối tượng được lưu trữ trong cơ sở dữ liệu.
  public DbSet<SuperHero> SuperHeroes { get; set; }
}