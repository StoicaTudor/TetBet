﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TetBet.Infrastructure.Persistence;

namespace TetBet.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220609080847_9_6_2022__11_08")]
    partial class _9_6_2022__11_08
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("CompetitionSportEntity", b =>
                {
                    b.Property<long>("CompetitionsId")
                        .HasColumnType("bigint");

                    b.Property<long>("SportEntitiesId")
                        .HasColumnType("bigint");

                    b.HasKey("CompetitionsId", "SportEntitiesId");

                    b.HasIndex("SportEntitiesId");

                    b.ToTable("CompetitionSportEntity");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.AccountDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<float>("AccountBalance")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("AccountDetails");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.Bet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("BetName")
                        .HasColumnType("text");

                    b.Property<long?>("GenericBetId")
                        .HasColumnType("bigint");

                    b.Property<long>("RapidApiId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GenericBetId");

                    b.ToTable("Bet");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.BettingTicket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AccountDetailsId")
                        .HasColumnType("bigint");

                    b.Property<int>("BettingTicketStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<float>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountDetailsId");

                    b.ToTable("BettingTicket");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.Competition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("CompetitionStatus")
                        .HasColumnType("int");

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("RapidApiId")
                        .HasColumnType("bigint");

                    b.Property<int>("Season")
                        .HasColumnType("int");

                    b.Property<long>("SportId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("SportId");

                    b.ToTable("Competition");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.GenericBet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GenericBet");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.Odd", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("BetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long?>("SportEventBetId")
                        .HasColumnType("bigint");

                    b.Property<float>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BetId");

                    b.HasIndex("SportEventBetId");

                    b.ToTable("Odd");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.RapidApiConfigData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RapidApiConfigData");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.RapidApiKey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ApiDescription")
                        .HasColumnType("text");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("RemainingCalls")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RapidApiKey");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.Sport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.SportEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<string>("HomeStadium")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("RapidApiId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("SportEntity");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.SportEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CompetitionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<long>("RapidApiId")
                        .HasColumnType("bigint");

                    b.Property<string>("SportEventDetails")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("SportEvent");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.SportEventBet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("BetId")
                        .HasColumnType("bigint");

                    b.Property<long>("SportEventId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BetId");

                    b.HasIndex("SportEventId");

                    b.ToTable("SportEventBet");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.SportRelatedHuman", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("NationalityId")
                        .HasColumnType("bigint");

                    b.Property<long>("RapidApiId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SportEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SportEntityId1")
                        .HasColumnType("bigint");

                    b.Property<int>("SportRelatedHumanType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NationalityId");

                    b.HasIndex("SportEntityId");

                    b.HasIndex("SportEntityId1");

                    b.ToTable("SportRelatedHuman");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AccountDetailsId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<float>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountDetailsId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("AccountDetailsId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountDetailsId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.UserBet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("BettingTicketId")
                        .HasColumnType("bigint");

                    b.Property<long>("SportEventBetId")
                        .HasColumnType("bigint");

                    b.Property<int>("UserBetStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BettingTicketId");

                    b.HasIndex("SportEventBetId");

                    b.ToTable("UserBet");
                });

            modelBuilder.Entity("CompetitionSportEntity", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.Competition", null)
                        .WithMany()
                        .HasForeignKey("CompetitionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TetBet.Infrastructure.Entities.SportEntity", null)
                        .WithMany()
                        .HasForeignKey("SportEntitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.Bet", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.GenericBet", null)
                        .WithMany("Bets")
                        .HasForeignKey("GenericBetId");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.BettingTicket", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.AccountDetails", "AccountDetails")
                        .WithMany("BettingTickets")
                        .HasForeignKey("AccountDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountDetails");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.Competition", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TetBet.Infrastructure.Entities.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.Odd", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.Bet", "Bet")
                        .WithMany()
                        .HasForeignKey("BetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TetBet.Infrastructure.Entities.SportEventBet", null)
                        .WithMany("Odds")
                        .HasForeignKey("SportEventBetId");

                    b.Navigation("Bet");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.SportEntity", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.SportEvent", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.SportEventBet", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.Bet", "Bet")
                        .WithMany()
                        .HasForeignKey("BetId");

                    b.HasOne("TetBet.Infrastructure.Entities.SportEvent", "SportEvent")
                        .WithMany("AvailableBets")
                        .HasForeignKey("SportEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bet");

                    b.Navigation("SportEvent");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.SportRelatedHuman", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.Country", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TetBet.Infrastructure.Entities.SportEntity", null)
                        .WithMany("Staff")
                        .HasForeignKey("SportEntityId");

                    b.HasOne("TetBet.Infrastructure.Entities.SportEntity", null)
                        .WithMany("Team")
                        .HasForeignKey("SportEntityId1");

                    b.Navigation("Nationality");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.Transaction", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.AccountDetails", "AccountDetails")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountDetails");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.User", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.AccountDetails", "AccountDetails")
                        .WithMany()
                        .HasForeignKey("AccountDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountDetails");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.UserBet", b =>
                {
                    b.HasOne("TetBet.Infrastructure.Entities.BettingTicket", null)
                        .WithMany("UserBets")
                        .HasForeignKey("BettingTicketId");

                    b.HasOne("TetBet.Infrastructure.Entities.SportEventBet", "SportEventBet")
                        .WithMany()
                        .HasForeignKey("SportEventBetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SportEventBet");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.AccountDetails", b =>
                {
                    b.Navigation("BettingTickets");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.BettingTicket", b =>
                {
                    b.Navigation("UserBets");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.GenericBet", b =>
                {
                    b.Navigation("Bets");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.SportEntity", b =>
                {
                    b.Navigation("Staff");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.SportEvent", b =>
                {
                    b.Navigation("AvailableBets");
                });

            modelBuilder.Entity("TetBet.Infrastructure.Entities.SportEventBet", b =>
                {
                    b.Navigation("Odds");
                });
#pragma warning restore 612, 618
        }
    }
}
