﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Consultium.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Consultium.Api.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    partial class RepositoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Consultant", b =>
                {
                    b.Property<Guid>("ConsultantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("consultant_id");

                    b.Property<Guid?>("ConsultantIds")
                        .HasColumnType("uuid")
                        .HasColumnName("consultant_ids");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<bool>("HasAsignment")
                        .HasColumnType("boolean")
                        .HasColumnName("has_asignment");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_name");

                    b.Property<string[]>("Skills")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("skills");

                    b.HasKey("ConsultantId")
                        .HasName("pk_consultants");

                    b.HasIndex("ConsultantIds")
                        .HasDatabaseName("ix_consultants_consultant_ids");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_consultants_customer_id");

                    b.ToTable("consultants", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("company_name");

                    b.Property<List<Guid>>("ConsultantIds")
                        .IsRequired()
                        .HasColumnType("uuid[]")
                        .HasColumnName("consultant_ids");

                    b.HasKey("CustomerId")
                        .HasName("pk_customers");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Consultant", b =>
                {
                    b.HasOne("Domain.Entities.Customer", null)
                        .WithMany("Consultants")
                        .HasForeignKey("ConsultantIds")
                        .HasConstraintName("fk_consultants_customers_consultant_ids");

                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("fk_consultants_customers_customer_id");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Navigation("Consultants");
                });
#pragma warning restore 612, 618
        }
    }
}
