﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagementWithUOW.EF;

namespace UserManagementWithUOW.EF.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("UserManagementWithUOW.Core.Models.Certifications", b =>
                {
                    b.Property<int>("CertificationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CertificationsId");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("UserManagementWithUOW.Core.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("UserManagementWithUOW.Core.Models.UsersCretifications", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CertificationsId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CertificationsId");

                    b.HasIndex("CertificationsId");

                    b.ToTable("UsersCretifications");
                });

            modelBuilder.Entity("UserManagementWithUOW.Core.Models.UsersCretifications", b =>
                {
                    b.HasOne("UserManagementWithUOW.Core.Models.Certifications", "Certifications")
                        .WithMany("UsersCretifications")
                        .HasForeignKey("CertificationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserManagementWithUOW.Core.Models.User", "users")
                        .WithMany("UsersCretifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Certifications");

                    b.Navigation("users");
                });

            modelBuilder.Entity("UserManagementWithUOW.Core.Models.Certifications", b =>
                {
                    b.Navigation("UsersCretifications");
                });

            modelBuilder.Entity("UserManagementWithUOW.Core.Models.User", b =>
                {
                    b.Navigation("UsersCretifications");
                });
#pragma warning restore 612, 618
        }
    }
}
