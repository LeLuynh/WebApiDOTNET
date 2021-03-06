// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eProjectDemoData.EF;

namespace eProjectDemoData.Migrations
{
    [DbContext(typeof(ProjectDemoContext))]
    [Migration("20210823021306_seeddata")]
    partial class seeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eProjectDemoData.Entity.AppConfig", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.ToTable("AppConfigs");
                });

            modelBuilder.Entity("eProjectDemoData.Entity.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2021, 8, 23, 9, 13, 5, 717, DateTimeKind.Local).AddTicks(470),
                            Description = "suitable for men and women",
                            Name = "Vanz"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2021, 8, 23, 9, 13, 5, 718, DateTimeKind.Local).AddTicks(6697),
                            Description = "suitable for men and women",
                            Name = "Convert"
                        },
                        new
                        {
                            Id = 3,
                            DateCreated = new DateTime(2021, 8, 23, 9, 13, 5, 718, DateTimeKind.Local).AddTicks(6779),
                            Description = "suitable for men and women",
                            Name = "Nike"
                        },
                        new
                        {
                            Id = 4,
                            DateCreated = new DateTime(2021, 8, 23, 9, 13, 5, 718, DateTimeKind.Local).AddTicks(6785),
                            Description = "suitable for men and women",
                            Name = "Biti"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
