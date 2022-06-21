﻿// <auto-generated />
using System;
using BancoAlimentar.AlimentaEstaIdeia.Sas.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancoAlimentar.AlimentaEstaIdeia.Sas.Model.Migrations
{
    [DbContext(typeof(InfrastructureDbContext))]
    [Migration("20220318104417_InvoiceConfiguration")]
    partial class InvoiceConfiguration
    {
        /// <summary>
        /// Builds the target model
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.DomainIdentifier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("DomainName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Environment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("DomainIdentifiers");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.InvoiceConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FooterSignatureImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeaderImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InvoiceConfigurations");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.KeyVaultConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Environment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("Vault")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("KeyVaultConfigurations");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InvoiceConfigurationId")
                        .HasColumnType("int");

                    b.Property<string>("InvoicingStrategy")
                        .IsRequired()
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStrategy")
                        .IsRequired()
                        .HasColumnType("nvarchar(180)");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceConfigurationId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.DomainIdentifier", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.Tenant", null)
                        .WithMany("Domains")
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.KeyVaultConfiguration", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.Tenant", null)
                        .WithMany("KeyVaultConfigurations")
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.Tenant", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.InvoiceConfiguration", "InvoiceConfiguration")
                        .WithMany()
                        .HasForeignKey("InvoiceConfigurationId");

                    b.Navigation("InvoiceConfiguration");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.Tenant", b =>
                {
                    b.Navigation("Domains");

                    b.Navigation("KeyVaultConfigurations");
                });
#pragma warning restore 612, 618
        }
    }
}
