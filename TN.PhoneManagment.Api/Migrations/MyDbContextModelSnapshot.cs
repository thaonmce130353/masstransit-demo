﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TN.PhoneManagment.Api;

#nullable disable

namespace TN.PhoneManagment.Api.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TN.PhoneManagment.Api.Models.Order", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("totalPrice")
                        .HasColumnType("float");

                    b.HasKey("CorrelationId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("TN.PhoneManagment.Api.Models.OrderPhone", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SmartPhoneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId", "SmartPhoneId");

                    b.HasIndex("SmartPhoneId");

                    b.ToTable("orderPhones");
                });

            modelBuilder.Entity("TN.PhoneManagment.Api.Models.SmartPhone", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("CorrelationId");

                    b.ToTable("phones");
                });

            modelBuilder.Entity("TN.PhoneManagment.Api.Models.OrderPhone", b =>
                {
                    b.HasOne("TN.PhoneManagment.Api.Models.Order", "Order")
                        .WithMany("OrderPhones")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TN.PhoneManagment.Api.Models.SmartPhone", "SmartPhone")
                        .WithMany("OrderPhones")
                        .HasForeignKey("SmartPhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("SmartPhone");
                });

            modelBuilder.Entity("TN.PhoneManagment.Api.Models.Order", b =>
                {
                    b.Navigation("OrderPhones");
                });

            modelBuilder.Entity("TN.PhoneManagment.Api.Models.SmartPhone", b =>
                {
                    b.Navigation("OrderPhones");
                });
#pragma warning restore 612, 618
        }
    }
}
