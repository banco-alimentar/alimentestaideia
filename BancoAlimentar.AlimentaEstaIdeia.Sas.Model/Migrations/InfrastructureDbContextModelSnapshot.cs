﻿// <auto-generated />
using System;
using BancoAlimentar.AlimentaEstaIdeia.Sas.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancoAlimentar.AlimentaEstaIdeia.Sas.Model.Migrations
{
    [DbContext(typeof(InfrastructureDbContext))]
    partial class InfrastructureDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
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

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7495),
                            DomainName = "localhost",
                            Environment = "Development",
                            TenantId = 5
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7495),
                            DomainName = "doar-dev.bancoalimentar.pt",
                            Environment = "Development",
                            TenantId = 7
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7496),
                            DomainName = "alimentaestaideia-beta.azurewebsites.net",
                            Environment = "Staging",
                            TenantId = 10
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7496),
                            DomainName = "doar-dev.alimentestaideia.pt",
                            Environment = "Staging",
                            TenantId = 10
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7497),
                            DomainName = "alimentaestaideia-developer.azurewebsites.net",
                            Environment = "Staging",
                            TenantId = 14
                        },
                        new
                        {
                            Id = 8,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7497),
                            DomainName = "alimentaestaideia-developer.azurewebsites.net",
                            Environment = "Development",
                            TenantId = 14
                        },
                        new
                        {
                            Id = 9,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7497),
                            DomainName = "doar-dev.bancoalimentar.pt",
                            Environment = "Staging",
                            TenantId = 7
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7468),
                            Environment = "Development",
                            TenantId = 7,
                            Vault = "doarbancoalimentar"
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7470),
                            Environment = "Development",
                            TenantId = 5,
                            Vault = "doarbancoalimentar"
                        },
                        new
                        {
                            Id = 8,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7471),
                            Environment = "Development",
                            TenantId = 10,
                            Vault = "doaralimentestaideia"
                        },
                        new
                        {
                            Id = 9,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7472),
                            Environment = "Development",
                            TenantId = 13,
                            Vault = "doaralimentestaideia"
                        },
                        new
                        {
                            Id = 10,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7473),
                            Environment = "Staging",
                            TenantId = 10,
                            Vault = "doaralimentestaideia"
                        },
                        new
                        {
                            Id = 11,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7474),
                            Environment = "Staging",
                            TenantId = 7,
                            Vault = "doarbancoalimentar"
                        },
                        new
                        {
                            Id = 12,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7475),
                            Environment = "Staging",
                            TenantId = 14,
                            Vault = "alimentaestaideia-key"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7283),
                            InvoicingStrategy = "MultipleTablesPerFoodBank",
                            Name = "localhost",
                            PaymentStrategy = "IndividualPaymentProcessorPerFoodBank",
                            PublicId = new Guid("9d46682c-588b-45ce-8829-f8ce771dc10e")
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7288),
                            InvoicingStrategy = "MultipleTablesPerFoodBank",
                            Name = "bancoalimentar",
                            PaymentStrategy = "SharedPaymentProcessor",
                            PublicId = new Guid("2d4d6448-71d3-454a-a584-9ebfc0b7ede5")
                        },
                        new
                        {
                            Id = 8,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7334),
                            InvoicingStrategy = "SingleInvoiceTable",
                            Name = "alimentaestaideia-beta",
                            PaymentStrategy = "SharedPaymentProcessor",
                            PublicId = new Guid("bd31d165-b8df-4c7a-a5e3-5e3d155948e2")
                        },
                        new
                        {
                            Id = 9,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7335),
                            InvoicingStrategy = "SingleInvoiceTable",
                            Name = "alimentaestaideia-beta",
                            PaymentStrategy = "SharedPaymentProcessor",
                            PublicId = new Guid("de68a683-0cd2-44ce-b9c6-505aabbcdfc3")
                        },
                        new
                        {
                            Id = 10,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7336),
                            InvoicingStrategy = "SingleInvoiceTable",
                            Name = "doar-dev.alimentestaideia.pt",
                            PaymentStrategy = "SharedPaymentProcessor",
                            PublicId = new Guid("03317653-9140-4cc0-91e0-2b2aa2a8e5fe")
                        },
                        new
                        {
                            Id = 13,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7338),
                            InvoicingStrategy = "SingleInvoiceTable",
                            Name = "doar-dev.alimentestaideia-dev.pt",
                            PaymentStrategy = "SharedPaymentProcessor",
                            PublicId = new Guid("f3aea354-b2ad-4451-893f-891dfb2c6c99")
                        },
                        new
                        {
                            Id = 14,
                            Created = new DateTime(2022, 5, 18, 17, 11, 59, 395, DateTimeKind.Utc).AddTicks(7340),
                            InvoicingStrategy = "SingleInvoiceTable",
                            Name = "alimentaestaideia-developer.azurewebsites.net",
                            PaymentStrategy = "SharedPaymentProcessor",
                            PublicId = new Guid("f904b771-b750-4392-a8f6-f76a8b9cc1be")
                        });
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.TenantConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("DeploymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KeyVaultSecretId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResourceGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("Test")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantConfigurations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.TenantConfiguration", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Sas.Model.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
