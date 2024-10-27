﻿// <auto-generated />
using System;
using FeedBackApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FeedBackApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241027094632_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FeedBackApp.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FeedBackApp.Model.Commit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FeedBackId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommitId");

                    b.HasIndex("FeedBackId");

                    b.HasIndex("UserId");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("FeedBackApp.Model.FeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdateStatus")
                        .HasColumnType("int");

                    b.Property<int>("UploadsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("FeedBackApp.Model.Upload", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FeedBackId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeedBackId");

                    b.HasIndex("UserId");

                    b.ToTable("Uploads");
                });

            modelBuilder.Entity("FeedBackApp.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FeedBackApp.Model.Commit", b =>
                {
                    b.HasOne("FeedBackApp.Model.Commit", null)
                        .WithMany()
                        .HasForeignKey("CommitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FeedBackApp.Model.FeedBack", "FeedBack")
                        .WithMany("Commits")
                        .HasForeignKey("FeedBackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedBackApp.Model.User", "User")
                        .WithMany("Commits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeedBack");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FeedBackApp.Model.FeedBack", b =>
                {
                    b.HasOne("FeedBackApp.Model.Category", "Category")
                        .WithMany("FeedBacks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FeedBackApp.Model.Upload", b =>
                {
                    b.HasOne("FeedBackApp.Model.FeedBack", "FeedBack")
                        .WithMany()
                        .HasForeignKey("FeedBackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedBackApp.Model.User", "User")
                        .WithMany("Uploads")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeedBack");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FeedBackApp.Model.Category", b =>
                {
                    b.Navigation("FeedBacks");
                });

            modelBuilder.Entity("FeedBackApp.Model.FeedBack", b =>
                {
                    b.Navigation("Commits");
                });

            modelBuilder.Entity("FeedBackApp.Model.User", b =>
                {
                    b.Navigation("Commits");

                    b.Navigation("Uploads");
                });
#pragma warning restore 612, 618
        }
    }
}
