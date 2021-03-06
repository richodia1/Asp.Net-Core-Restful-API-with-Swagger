﻿// <auto-generated />
using System;
using LogicXPro.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogicXPro.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20180916074740_RefactorEntity")]
    partial class RefactorEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LogicXPro.Infrastructure.Entities.Coffee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoffeeType");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<int>("PreparationTime");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Coffees");
                });

            modelBuilder.Entity("LogicXPro.Infrastructure.Entities.Customer", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Picture");

                    b.Property<string>("Title");

                    b.HasKey("UserID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LogicXPro.Infrastructure.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerUserID");

                    b.Property<bool>("IsCanceled");

                    b.Property<DateTime>("OrderDate");

                    b.Property<DateTime>("StartPreparationTime");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerUserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("LogicXPro.Infrastructure.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoffeeId");

                    b.Property<int>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("CoffeeId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("LogicXPro.Infrastructure.Entities.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LogicXPro.Infrastructure.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LogicXPro.Infrastructure.Entities.UserRole", b =>
                {
                    b.Property<int>("UserRoleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleID");

                    b.Property<int>("UserID");

                    b.HasKey("UserRoleID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("LogicXPro.Infrastructure.Entities.Customer", b =>
                {
                    b.HasOne("LogicXPro.Infrastructure.Entities.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("LogicXPro.Infrastructure.Entities.Customer", "UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LogicXPro.Infrastructure.Entities.Order", b =>
                {
                    b.HasOne("LogicXPro.Infrastructure.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerUserID");
                });

            modelBuilder.Entity("LogicXPro.Infrastructure.Entities.OrderDetail", b =>
                {
                    b.HasOne("LogicXPro.Infrastructure.Entities.Coffee", "Coffee")
                        .WithMany("OrderDetails")
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LogicXPro.Infrastructure.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LogicXPro.Infrastructure.Entities.UserRole", b =>
                {
                    b.HasOne("LogicXPro.Infrastructure.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LogicXPro.Infrastructure.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
