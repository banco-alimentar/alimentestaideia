﻿// <auto-generated />
using System;
using BancoAlimentar.AlimentaEstaIdeia.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BancoAlimentar.AlimentaEstaIdeia.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210524194758_Invoice-Donation-IsUnique")]
    partial class InvoiceDonationIsUnique
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.BasePayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BasePayment");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDefaultCampaign")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DonationAmount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FoodBankId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Referral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceEntity")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ServiceReference")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("WantsReceipt")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FoodBankId");

                    b.HasIndex("UserId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.DonationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DonationId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int?>("ProductCatalogueId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonationId");

                    b.HasIndex("ProductCatalogueId");

                    b.ToTable("DonationItems");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.DonorAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Address2")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("City")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("DonorAddresses");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.FoodBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FoodBanks");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationRole", b =>
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

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationUserLogin", b =>
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

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationUserToken", b =>
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

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.WebUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nif")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NIF");

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

                    b.Property<string>("PreferedFoodBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DonationId")
                        .HasColumnType("int");

                    b.Property<Guid>("InvoicePublicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DonationId")
                        .IsUnique()
                        .HasFilter("[DonationId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.PaymentItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DonationId")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonationId");

                    b.HasIndex("PaymentId");

                    b.ToTable("PaymentItems");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.ProductCatalogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("decimal(5,3)");

                    b.Property<string>("UnitOfMeasure")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("ProductCatalogues");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.CreditCardPayment", b =>
                {
                    b.HasBaseType("BancoAlimentar.AlimentaEstaIdeia.Model.BasePayment");

                    b.Property<string>("EasyPayPaymentId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("FixedFee")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.Property<float>("Paid")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.Property<float>("Requested")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.Property<float>("Tax")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.Property<float>("Transfer")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("VariableFee")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.HasDiscriminator().HasValue("CreditCardPayment");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.MBWayPayment", b =>
                {
                    b.HasBaseType("BancoAlimentar.AlimentaEstaIdeia.Model.BasePayment");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EasyPayPaymentId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("FixedFee")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.Property<float>("Paid")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.Property<float>("Requested")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.Property<float>("Tax")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.Property<float>("Transfer")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.Property<float>("VariableFee")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real");

                    b.HasDiscriminator().HasValue("MBWayPayment");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.MultiBankPayment", b =>
                {
                    b.HasBaseType("BancoAlimentar.AlimentaEstaIdeia.Model.BasePayment");

                    b.Property<string>("EasyPayPaymentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("MultiBankPayment");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.PayPalPayment", b =>
                {
                    b.HasBaseType("BancoAlimentar.AlimentaEstaIdeia.Model.BasePayment");

                    b.Property<string>("PayPalPaymentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PayPalPayment");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Donation", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.FoodBank", "FoodBank")
                        .WithMany()
                        .HasForeignKey("FoodBankId");

                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.WebUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("FoodBank");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.DonationItem", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Donation", "Donation")
                        .WithMany("DonationItems")
                        .HasForeignKey("DonationId");

                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.ProductCatalogue", "ProductCatalogue")
                        .WithMany()
                        .HasForeignKey("ProductCatalogueId");

                    b.Navigation("Donation");

                    b.Navigation("ProductCatalogue");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationRoleClaim", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationRole", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationUserClaim", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.WebUser", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationUserLogin", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.WebUser", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationUserRole", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.WebUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationUserToken", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.WebUser", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.WebUser", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.DonorAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Invoice", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Donation", "Donation")
                        .WithMany()
                        .HasForeignKey("DonationId");

                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.WebUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Donation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.PaymentItem", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Donation", "Donation")
                        .WithMany("Payments")
                        .HasForeignKey("DonationId");

                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.BasePayment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.Navigation("Donation");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.ProductCatalogue", b =>
                {
                    b.HasOne("BancoAlimentar.AlimentaEstaIdeia.Model.Campaign", "Campaign")
                        .WithMany("ProductCatalogues")
                        .HasForeignKey("CampaignId");

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Campaign", b =>
                {
                    b.Navigation("ProductCatalogues");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Donation", b =>
                {
                    b.Navigation("DonationItems");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.ApplicationRole", b =>
                {
                    b.Navigation("RoleClaims");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BancoAlimentar.AlimentaEstaIdeia.Model.Identity.WebUser", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Logins");

                    b.Navigation("Tokens");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
