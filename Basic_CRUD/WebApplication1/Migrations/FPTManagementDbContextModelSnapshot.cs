﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(FPTManagementDbContext))]
    partial class FPTManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Model.Address", b =>
                {
                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("WebApplication1.Model.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonRole")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Professor");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Professors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "professor1@example.com",
                            Name = "Professor1",
                            PersonRole = "Professor",
                            Phone = "0987654321",
                            Salary = 5000f
                        },
                        new
                        {
                            Id = 2,
                            Email = "professor2@example.com",
                            Name = "Professor2",
                            PersonRole = "Professor",
                            Phone = "0987654321",
                            Salary = 5000f
                        },
                        new
                        {
                            Id = 3,
                            Email = "professor3@example.com",
                            Name = "Professor3",
                            PersonRole = "Professor",
                            Phone = "0987654321",
                            Salary = 5000f
                        },
                        new
                        {
                            Id = 4,
                            Email = "professor4@example.com",
                            Name = "Professor4",
                            PersonRole = "Professor",
                            Phone = "0987654321",
                            Salary = 5000f
                        },
                        new
                        {
                            Id = 5,
                            Email = "professor5@example.com",
                            Name = "Professor5",
                            PersonRole = "Professor",
                            Phone = "0987654321",
                            Salary = 5000f
                        });
                });

            modelBuilder.Entity("WebApplication1.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Gpa")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonRole")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Student");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "student1@example.com",
                            Gpa = 3.5f,
                            Name = "Student1",
                            PersonRole = "Student",
                            Phone = "0123456789"
                        },
                        new
                        {
                            Id = 2,
                            Email = "student2@example.com",
                            Gpa = 3.5f,
                            Name = "Student1",
                            PersonRole = "Student",
                            Phone = "0223456789"
                        },
                        new
                        {
                            Id = 3,
                            Email = "student3@example.com",
                            Gpa = 3.5f,
                            Name = "Student1",
                            PersonRole = "Student",
                            Phone = "0323456789"
                        },
                        new
                        {
                            Id = 4,
                            Email = "student4@example.com",
                            Gpa = 3.5f,
                            Name = "Student1",
                            PersonRole = "Student",
                            Phone = "0423456789"
                        },
                        new
                        {
                            Id = 5,
                            Email = "student5@example.com",
                            Gpa = 3.5f,
                            Name = "Student1",
                            PersonRole = "Student",
                            Phone = "0523456789"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
