using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess;

public partial class TatooWebContext : DbContext
{
    public TatooWebContext()
    {
    }

    public TatooWebContext(DbContextOptions<TatooWebContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Account> Accounts { get; set; } = null!;
    public virtual DbSet<ArtWork> ArtWorks { get; set; } = null!;
    public virtual DbSet<Artist> Artists { get; set; } = null!;
    public virtual DbSet<Booking> Bookings { get; set; } = null!;
    public virtual DbSet<Customer> Customers { get; set; } = null!;
    public virtual DbSet<Discount> Discounts { get; set; } = null!;
    public virtual DbSet<Equipment> Equipment { get; set; } = null!;
    public virtual DbSet<Image> Images { get; set; } = null!;
    public virtual DbSet<Scheduling> Schedulings { get; set; } = null!;
    public virtual DbSet<Studio> Studios { get; set; } = null!;
    public virtual DbSet<VipMember> VipMembers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
    }

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        var strConn = config["ConnectionStrings:DatabaseConnection"];
        return strConn;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");

            entity.Property(e => e.Email).HasMaxLength(255);

            entity.Property(e => e.Password).HasMaxLength(255);

            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<ArtWork>(entity =>
        {
            entity.ToTable("ArtWork");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Description).HasColumnType("text");

            entity.Property(e => e.Position).HasMaxLength(255);

            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Artist)
                .WithMany(p => p.ArtWorks)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK_ArtWork_Artist");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.ToTable("Artist");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Studio)
                .WithMany(p => p.Artists)
                .HasForeignKey(d => d.StudioId)
                .HasConstraintName("FK_Artist_Studio");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Description).HasColumnType("text");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ArtWork)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ArtWorkId)
                .HasConstraintName("FK_Booking_ArtWork");

            entity.HasOne(d => d.Artist)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK_Booking_Artist");

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Booking_Customer");

            entity.HasOne(d => d.Equipment)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK_Booking_Equipment");

            entity.HasOne(d => d.Studio)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.StudioId)
                .HasConstraintName("FK_Booking_Studio");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Address).HasMaxLength(255);

            entity.Property(e => e.FirstName).HasMaxLength(255);

            entity.Property(e => e.LastName).HasMaxLength(255);

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Customer_Account");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.ToTable("Discount");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.EndDate).HasColumnType("date");

            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Studio)
                .WithMany(p => p.Discounts)
                .HasForeignKey(d => d.StudioId)
                .HasConstraintName("FK_Discount_Studio");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.Property(e => e.Position).HasMaxLength(255);

            entity.HasOne(d => d.Studio)
                .WithMany(p => p.Equipment)
                .HasForeignKey(d => d.StudioId)
                .HasConstraintName("FK_Equipment_Studio");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("Image");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.EntityId).HasMaxLength(255);

            entity.Property(e => e.Source).HasMaxLength(255);
        });

        modelBuilder.Entity<Scheduling>(entity =>
        {
            entity.ToTable("Scheduling");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Date).HasColumnType("date");

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Booking)
                .WithMany(p => p.Schedulings)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK_Scheduling_Booking");
        });

        modelBuilder.Entity<Studio>(entity =>
        {
            entity.ToTable("Studio");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Address).HasMaxLength(255);

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.StudioEmail).HasMaxLength(255);

            entity.Property(e => e.StudioPhone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Studios)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Studio_Account");
        });

        modelBuilder.Entity<VipMember>(entity =>
        {
            entity.ToTable("VipMember");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.VipMembers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_VipMember_Customer");

            entity.HasOne(d => d.Studio)
                .WithMany(p => p.VipMembers)
                .HasForeignKey(d => d.StudioId)
                .HasConstraintName("FK_VipMember_Studio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}