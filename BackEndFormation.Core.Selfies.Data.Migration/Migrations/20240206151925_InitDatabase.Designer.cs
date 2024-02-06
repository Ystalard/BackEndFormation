﻿// <auto-generated />
using System;
using BackEndFormation.Core.Selfies.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndFormation.Core.Selfies.Data.Migration.Migrations
{
    [DbContext(typeof(SelfiesContext))]
    [Migration("20240206151925_InitDatabase")]
    partial class InitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackEndFormation.Core.Selfies.Domain.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Picture", (string)null);
                });

            modelBuilder.Entity("BackEndFormation.Core.Selfies.Domain.Selfie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PictureId")
                        .HasColumnType("int");

                    b.Property<int>("PicutreId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WookieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("WookieId");

                    b.ToTable("Selfie", (string)null);
                });

            modelBuilder.Entity("BackEndFormation.Core.Selfies.Domain.Wookie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wookie", (string)null);
                });

            modelBuilder.Entity("BackEndFormation.Core.Selfies.Domain.Selfie", b =>
                {
                    b.HasOne("BackEndFormation.Core.Selfies.Domain.Picture", "Picture")
                        .WithMany("Selfies")
                        .HasForeignKey("PictureId");

                    b.HasOne("BackEndFormation.Core.Selfies.Domain.Wookie", "Wookie")
                        .WithMany("Selfies")
                        .HasForeignKey("WookieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Picture");

                    b.Navigation("Wookie");
                });

            modelBuilder.Entity("BackEndFormation.Core.Selfies.Domain.Picture", b =>
                {
                    b.Navigation("Selfies");
                });

            modelBuilder.Entity("BackEndFormation.Core.Selfies.Domain.Wookie", b =>
                {
                    b.Navigation("Selfies");
                });
#pragma warning restore 612, 618
        }
    }
}
