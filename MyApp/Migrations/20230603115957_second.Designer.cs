﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApp;

#nullable disable

namespace MyApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230603115957_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MyApp.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("StudentsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentsId");

                    b.ToTable("Dbmodules");
                });

            modelBuilder.Entity("MyApp.Models.StudentModules", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "ModuleId");

                    b.HasIndex("ModuleId");

                    b.ToTable("DbstudentModules");
                });

            modelBuilder.Entity("MyApp.Models.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TelNo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Dbstudnets");
                });

            modelBuilder.Entity("MyApp.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Dbusers");
                });

            modelBuilder.Entity("MyApp.Models.Module", b =>
                {
                    b.HasOne("MyApp.Models.Students", null)
                        .WithMany("modules")
                        .HasForeignKey("StudentsId");
                });

            modelBuilder.Entity("MyApp.Models.StudentModules", b =>
                {
                    b.HasOne("MyApp.Models.Module", "Module")
                        .WithMany("StudentModules")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyApp.Models.Students", "Students")
                        .WithMany("StudentModules")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("MyApp.Models.Module", b =>
                {
                    b.Navigation("StudentModules");
                });

            modelBuilder.Entity("MyApp.Models.Students", b =>
                {
                    b.Navigation("StudentModules");

                    b.Navigation("modules");
                });
#pragma warning restore 612, 618
        }
    }
}
