// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _02_ef_university_db.Data;

#nullable disable

namespace _02_ef_university_db.Migrations
{
    [DbContext(typeof(UniversityDbContext))]
    partial class UniversityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_02_ef_university_db.Entities.Teacher", b =>
                {
                    b.Property<int>("Identity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Identity"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FirstName");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LastName");

                    b.HasKey("Identity");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("_02_ef_university_db.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kyiv"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kharkiv"
                        });
                });

            modelBuilder.Entity("_02_ef_university_db.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("AverageMark")
                        .HasColumnType("real");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Soborna street 5a, Rivne Ukraine",
                            AverageMark = 8.7f,
                            Birthdate = new DateTime(2003, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 1,
                            Name = "Igor"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Poshtova street 7b, Rivne Ukraine",
                            AverageMark = 9.5f,
                            Birthdate = new DateTime(2005, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 2,
                            Name = "Olga"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Soborna street 5a, Rivne Ukraine",
                            AverageMark = 10.3f,
                            Birthdate = new DateTime(2005, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 1,
                            Name = "Sasha"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Soborna street 10a, Rivne Ukraine",
                            AverageMark = 11.3f,
                            Birthdate = new DateTime(2004, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 2,
                            Name = "Viktoria"
                        });
                });

            modelBuilder.Entity("_02_ef_university_db.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects", (string)null);
                });

            modelBuilder.Entity("GroupSubject", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("GroupSubject", (string)null);
                });

            modelBuilder.Entity("_02_ef_university_db.Student", b =>
                {
                    b.HasOne("_02_ef_university_db.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("GroupSubject", b =>
                {
                    b.HasOne("_02_ef_university_db.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_02_ef_university_db.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_02_ef_university_db.Group", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
