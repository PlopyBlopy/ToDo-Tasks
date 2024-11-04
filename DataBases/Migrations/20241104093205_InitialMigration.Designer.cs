﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoTask.DataBases;

#nullable disable

namespace ToDoTask.DataBases.Migrations
{
    [DbContext(typeof(ApplicationSQLliteContext))]
    [Migration("20241104093205_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("ToDoTask.DataBases.Entitys.GroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Groups", (string)null);
                });

            modelBuilder.Entity("ToDoTask.DataBases.Entitys.TaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupEntityId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("ToDoTask.DataBases.Entitys.TaskEntity", b =>
                {
                    b.HasOne("ToDoTask.DataBases.Entitys.GroupEntity", "GroupEntity")
                        .WithMany("Tasks")
                        .HasForeignKey("GroupEntityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GroupEntity");
                });

            modelBuilder.Entity("ToDoTask.DataBases.Entitys.GroupEntity", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
