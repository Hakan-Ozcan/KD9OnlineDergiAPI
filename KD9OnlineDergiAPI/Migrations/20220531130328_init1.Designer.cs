// <auto-generated />
using System;
using KD9OnlineDergiAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KD9OnlineDergiAPI.Migrations
{
    [DbContext(typeof(DergiDbContext))]
    [Migration("20220531130328_init1")]
    partial class init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KD9OnlineDergiAPI.Model.Dergi", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("dergiAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("dergiTürleri")
                        .HasColumnType("int");

                    b.Property<int>("yayınAralığı")
                        .HasColumnType("int");

                    b.Property<int>("yayınEviId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("dergiAdı")
                        .IsUnique();

                    b.HasIndex("yayınEviId");

                    b.ToTable("Dergiler");
                });

            modelBuilder.Entity("KD9OnlineDergiAPI.Model.Sayı", b =>
                {
                    b.Property<Guid>("DergiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("sayı")
                        .HasColumnType("int");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SayfaSayısı")
                        .HasColumnType("int");

                    b.Property<DateTime>("YayınTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("DergiId", "sayı");

                    b.ToTable("Sayılar");
                });

            modelBuilder.Entity("KD9OnlineDergiAPI.Model.YayınEvi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("YayınEvleri");
                });

            modelBuilder.Entity("KD9OnlineDergiAPI.Model.Yazar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Yazarlar");
                });

            modelBuilder.Entity("SayıYazar", b =>
                {
                    b.Property<int>("YazarlarId")
                        .HasColumnType("int");

                    b.Property<Guid>("YazdığıSayılarDergiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("YazdığıSayılarsayı")
                        .HasColumnType("int");

                    b.HasKey("YazarlarId", "YazdığıSayılarDergiId", "YazdığıSayılarsayı");

                    b.HasIndex("YazdığıSayılarDergiId", "YazdığıSayılarsayı");

                    b.ToTable("SayıYazar");
                });

            modelBuilder.Entity("KD9OnlineDergiAPI.Model.Dergi", b =>
                {
                    b.HasOne("KD9OnlineDergiAPI.Model.YayınEvi", "yayınEvi")
                        .WithMany("Dergiler")
                        .HasForeignKey("yayınEviId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("yayınEvi");
                });

            modelBuilder.Entity("KD9OnlineDergiAPI.Model.Sayı", b =>
                {
                    b.HasOne("KD9OnlineDergiAPI.Model.Dergi", "Dergi")
                        .WithMany("Sayılar")
                        .HasForeignKey("DergiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dergi");
                });

            modelBuilder.Entity("SayıYazar", b =>
                {
                    b.HasOne("KD9OnlineDergiAPI.Model.Yazar", null)
                        .WithMany()
                        .HasForeignKey("YazarlarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KD9OnlineDergiAPI.Model.Sayı", null)
                        .WithMany()
                        .HasForeignKey("YazdığıSayılarDergiId", "YazdığıSayılarsayı")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KD9OnlineDergiAPI.Model.Dergi", b =>
                {
                    b.Navigation("Sayılar");
                });

            modelBuilder.Entity("KD9OnlineDergiAPI.Model.YayınEvi", b =>
                {
                    b.Navigation("Dergiler");
                });
#pragma warning restore 612, 618
        }
    }
}
