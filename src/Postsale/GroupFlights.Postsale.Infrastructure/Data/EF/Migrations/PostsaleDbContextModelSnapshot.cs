﻿// <auto-generated />
using System;
using GroupFlights.Postsale.Infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GroupFlights.Postsale.Infrastructure.Data.EF.Migrations
{
    [DbContext(typeof(PostsaleDbContext))]
    partial class PostsaleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("postsale")
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GroupFlights.Postsale.Domain.Changes.Outcome.ReservationChangeToApply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ChangesToApply", "postsale");
                });

            modelBuilder.Entity("GroupFlights.Postsale.Domain.Changes.Request.ReservationChangeRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("_changeToApplyId")
                        .HasColumnType("uuid");

                    b.Property<int?>("_completionStatus")
                        .HasColumnType("integer");

                    b.Property<bool>("_isActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("_isFeasible")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("_newTravelDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("_requester")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("_reservationToChangeReservationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("_changeToApplyId");

                    b.HasIndex("_reservationToChangeReservationId");

                    b.ToTable("ChangeRequests", "postsale");
                });

            modelBuilder.Entity("GroupFlights.Postsale.Domain.Changes.Request.ReservationToChange", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AirlineType")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.HasKey("ReservationId");

                    b.ToTable("ReservationSnapshots", "postsale");
                });

            modelBuilder.Entity("GroupFlights.Postsale.Domain.Changes.Outcome.ReservationChangeToApply", b =>
                {
                    b.OwnsOne("GroupFlights.Postsale.Domain.Changes.Outcome.PassengerNamesDeadlineChange", "_passengerNamesDeadlineChange", b1 =>
                        {
                            b1.Property<Guid>("ReservationChangeToApplyId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("DeadlineId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("NewDueDate")
                                .HasColumnType("timestamp without time zone");

                            b1.HasKey("ReservationChangeToApplyId");

                            b1.ToTable("ChangesToApply", "postsale");

                            b1.WithOwner()
                                .HasForeignKey("ReservationChangeToApplyId");
                        });

                    b.OwnsMany("GroupFlights.Postsale.Domain.Changes.Outcome.PaymentDeadlineChange", "_paymentDeadlineChanges", b1 =>
                        {
                            b1.Property<Guid>("ReservationChangeToApplyId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("DeadlineId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("NewDueDate")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<Guid>("PaymentId")
                                .HasColumnType("uuid");

                            b1.HasKey("ReservationChangeToApplyId", "Id");

                            b1.ToTable("PaymentDeadlineChange", "postsale");

                            b1.WithOwner()
                                .HasForeignKey("ReservationChangeToApplyId");
                        });

                    b.OwnsOne("GroupFlights.Postsale.Domain.Changes.Outcome.ReservationCost", "_costAfterChange", b1 =>
                        {
                            b1.Property<Guid>("ReservationChangeToApplyId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.HasKey("ReservationChangeToApplyId");

                            b1.ToTable("ChangesToApply", "postsale");

                            b1.WithOwner()
                                .HasForeignKey("ReservationChangeToApplyId");

                            b1.OwnsOne("GroupFlights.Shared.Types.Money", "RefundableCost", b2 =>
                                {
                                    b2.Property<Guid>("ReservationCostReservationChangeToApplyId")
                                        .HasColumnType("uuid");

                                    b2.Property<decimal>("Amount")
                                        .HasColumnType("numeric");

                                    b2.Property<int>("Currency")
                                        .HasColumnType("integer");

                                    b2.HasKey("ReservationCostReservationChangeToApplyId");

                                    b2.ToTable("ChangesToApply", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("ReservationCostReservationChangeToApplyId");
                                });

                            b1.OwnsOne("GroupFlights.Shared.Types.Money", "TotalCost", b2 =>
                                {
                                    b2.Property<Guid>("ReservationCostReservationChangeToApplyId")
                                        .HasColumnType("uuid");

                                    b2.Property<decimal>("Amount")
                                        .HasColumnType("numeric");

                                    b2.Property<int>("Currency")
                                        .HasColumnType("integer");

                                    b2.HasKey("ReservationCostReservationChangeToApplyId");

                                    b2.ToTable("ChangesToApply", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("ReservationCostReservationChangeToApplyId");
                                });

                            b1.Navigation("RefundableCost")
                                .IsRequired();

                            b1.Navigation("TotalCost")
                                .IsRequired();
                        });

                    b.OwnsOne("GroupFlights.Postsale.Domain.Changes.Outcome.TravelChange", "_travelTravelChange", b1 =>
                        {
                            b1.Property<Guid>("ReservationChangeToApplyId")
                                .HasColumnType("uuid");

                            b1.HasKey("ReservationChangeToApplyId");

                            b1.ToTable("ChangesToApply", "postsale");

                            b1.WithOwner()
                                .HasForeignKey("ReservationChangeToApplyId");

                            b1.OwnsMany("GroupFlights.Postsale.Domain.Shared.FlightSegment", "NewTravelSegments", b2 =>
                                {
                                    b2.Property<Guid>("TravelChangeReservationChangeToApplyId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b2.Property<int>("Id"));

                                    b2.Property<DateTime>("Date")
                                        .HasColumnType("timestamp without time zone");

                                    b2.HasKey("TravelChangeReservationChangeToApplyId", "Id");

                                    b2.ToTable("ChangesToApply_NewTravelSegments", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("TravelChangeReservationChangeToApplyId");

                                    b2.OwnsOne("GroupFlights.Postsale.Domain.Shared.FlightTime", "FlightTime", b3 =>
                                        {
                                            b3.Property<Guid>("FlightSegmentTravelChangeReservationChangeToApplyId")
                                                .HasColumnType("uuid");

                                            b3.Property<int>("FlightSegmentId")
                                                .HasColumnType("integer");

                                            b3.Property<int>("Hours")
                                                .HasColumnType("integer");

                                            b3.Property<int>("Minutes")
                                                .HasColumnType("integer");

                                            b3.HasKey("FlightSegmentTravelChangeReservationChangeToApplyId", "FlightSegmentId");

                                            b3.ToTable("ChangesToApply_NewTravelSegments", "postsale");

                                            b3.WithOwner()
                                                .HasForeignKey("FlightSegmentTravelChangeReservationChangeToApplyId", "FlightSegmentId");
                                        });

                                    b2.OwnsOne("GroupFlights.Shared.Types.Airport", "SourceAirport", b3 =>
                                        {
                                            b3.Property<Guid>("FlightSegmentTravelChangeReservationChangeToApplyId")
                                                .HasColumnType("uuid");

                                            b3.Property<int>("FlightSegmentId")
                                                .HasColumnType("integer");

                                            b3.Property<string>("City")
                                                .HasColumnType("text");

                                            b3.Property<string>("Code")
                                                .IsRequired()
                                                .HasColumnType("text");

                                            b3.Property<string>("Country")
                                                .HasColumnType("text");

                                            b3.Property<string>("Name")
                                                .HasColumnType("text");

                                            b3.HasKey("FlightSegmentTravelChangeReservationChangeToApplyId", "FlightSegmentId");

                                            b3.ToTable("ChangesToApply_NewTravelSegments", "postsale");

                                            b3.WithOwner()
                                                .HasForeignKey("FlightSegmentTravelChangeReservationChangeToApplyId", "FlightSegmentId");
                                        });

                                    b2.OwnsOne("GroupFlights.Shared.Types.Airport", "TargetAirport", b3 =>
                                        {
                                            b3.Property<Guid>("FlightSegmentTravelChangeReservationChangeToApplyId")
                                                .HasColumnType("uuid");

                                            b3.Property<int>("FlightSegmentId")
                                                .HasColumnType("integer");

                                            b3.Property<string>("City")
                                                .HasColumnType("text");

                                            b3.Property<string>("Code")
                                                .IsRequired()
                                                .HasColumnType("text");

                                            b3.Property<string>("Country")
                                                .HasColumnType("text");

                                            b3.Property<string>("Name")
                                                .HasColumnType("text");

                                            b3.HasKey("FlightSegmentTravelChangeReservationChangeToApplyId", "FlightSegmentId");

                                            b3.ToTable("ChangesToApply_NewTravelSegments", "postsale");

                                            b3.WithOwner()
                                                .HasForeignKey("FlightSegmentTravelChangeReservationChangeToApplyId", "FlightSegmentId");
                                        });

                                    b2.Navigation("FlightTime");

                                    b2.Navigation("SourceAirport");

                                    b2.Navigation("TargetAirport");
                                });

                            b1.Navigation("NewTravelSegments");
                        });

                    b.Navigation("_costAfterChange")
                        .IsRequired();

                    b.Navigation("_passengerNamesDeadlineChange");

                    b.Navigation("_paymentDeadlineChanges");

                    b.Navigation("_travelTravelChange");
                });

            modelBuilder.Entity("GroupFlights.Postsale.Domain.Changes.Request.ReservationChangeRequest", b =>
                {
                    b.HasOne("GroupFlights.Postsale.Domain.Changes.Outcome.ReservationChangeToApply", "_changeToApply")
                        .WithMany()
                        .HasForeignKey("_changeToApplyId");

                    b.HasOne("GroupFlights.Postsale.Domain.Changes.Request.ReservationToChange", "_reservationToChange")
                        .WithMany()
                        .HasForeignKey("_reservationToChangeReservationId");

                    b.OwnsOne("GroupFlights.Postsale.Domain.Changes.Outcome.ReservationCost", "_newCost", b1 =>
                        {
                            b1.Property<Guid>("ReservationChangeRequestId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.HasKey("ReservationChangeRequestId");

                            b1.ToTable("ChangeRequests", "postsale");

                            b1.WithOwner()
                                .HasForeignKey("ReservationChangeRequestId");

                            b1.OwnsOne("GroupFlights.Shared.Types.Money", "RefundableCost", b2 =>
                                {
                                    b2.Property<Guid>("ReservationCostReservationChangeRequestId")
                                        .HasColumnType("uuid");

                                    b2.Property<decimal>("Amount")
                                        .HasColumnType("numeric");

                                    b2.Property<int>("Currency")
                                        .HasColumnType("integer");

                                    b2.HasKey("ReservationCostReservationChangeRequestId");

                                    b2.ToTable("ChangeRequests", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("ReservationCostReservationChangeRequestId");
                                });

                            b1.OwnsOne("GroupFlights.Shared.Types.Money", "TotalCost", b2 =>
                                {
                                    b2.Property<Guid>("ReservationCostReservationChangeRequestId")
                                        .HasColumnType("uuid");

                                    b2.Property<decimal>("Amount")
                                        .HasColumnType("numeric");

                                    b2.Property<int>("Currency")
                                        .HasColumnType("integer");

                                    b2.HasKey("ReservationCostReservationChangeRequestId");

                                    b2.ToTable("ChangeRequests", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("ReservationCostReservationChangeRequestId");
                                });

                            b1.Navigation("RefundableCost")
                                .IsRequired();

                            b1.Navigation("TotalCost")
                                .IsRequired();
                        });

                    b.OwnsMany("GroupFlights.Postsale.Domain.Shared.FlightSegment", "_newTravel", b1 =>
                        {
                            b1.Property<Guid>("ReservationChangeRequestId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp without time zone");

                            b1.HasKey("ReservationChangeRequestId", "Id");

                            b1.ToTable("ChangeRequests__newTravel", "postsale");

                            b1.WithOwner()
                                .HasForeignKey("ReservationChangeRequestId");

                            b1.OwnsOne("GroupFlights.Postsale.Domain.Shared.FlightTime", "FlightTime", b2 =>
                                {
                                    b2.Property<Guid>("FlightSegmentReservationChangeRequestId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("FlightSegmentId")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Hours")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Minutes")
                                        .HasColumnType("integer");

                                    b2.HasKey("FlightSegmentReservationChangeRequestId", "FlightSegmentId");

                                    b2.ToTable("ChangeRequests__newTravel", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("FlightSegmentReservationChangeRequestId", "FlightSegmentId");
                                });

                            b1.OwnsOne("GroupFlights.Shared.Types.Airport", "SourceAirport", b2 =>
                                {
                                    b2.Property<Guid>("FlightSegmentReservationChangeRequestId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("FlightSegmentId")
                                        .HasColumnType("integer");

                                    b2.Property<string>("City")
                                        .HasColumnType("text");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Country")
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .HasColumnType("text");

                                    b2.HasKey("FlightSegmentReservationChangeRequestId", "FlightSegmentId");

                                    b2.ToTable("ChangeRequests__newTravel", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("FlightSegmentReservationChangeRequestId", "FlightSegmentId");
                                });

                            b1.OwnsOne("GroupFlights.Shared.Types.Airport", "TargetAirport", b2 =>
                                {
                                    b2.Property<Guid>("FlightSegmentReservationChangeRequestId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("FlightSegmentId")
                                        .HasColumnType("integer");

                                    b2.Property<string>("City")
                                        .HasColumnType("text");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Country")
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .HasColumnType("text");

                                    b2.HasKey("FlightSegmentReservationChangeRequestId", "FlightSegmentId");

                                    b2.ToTable("ChangeRequests__newTravel", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("FlightSegmentReservationChangeRequestId", "FlightSegmentId");
                                });

                            b1.Navigation("FlightTime");

                            b1.Navigation("SourceAirport");

                            b1.Navigation("TargetAirport");
                        });

                    b.OwnsOne("GroupFlights.Postsale.Domain.Changes.Payments.RequiredPayment", "_paymentRequiredToApplyChange", b1 =>
                        {
                            b1.Property<Guid>("ReservationChangeRequestId")
                                .HasColumnType("uuid");

                            b1.Property<bool>("Payed")
                                .HasColumnType("boolean");

                            b1.Property<Guid>("PaymentId")
                                .HasColumnType("uuid");

                            b1.HasKey("ReservationChangeRequestId");

                            b1.ToTable("ChangeRequests", "postsale");

                            b1.WithOwner()
                                .HasForeignKey("ReservationChangeRequestId");

                            b1.OwnsOne("GroupFlights.Postsale.Domain.Shared.Deadline", "Deadline", b2 =>
                                {
                                    b2.Property<Guid>("RequiredPaymentReservationChangeRequestId")
                                        .HasColumnType("uuid");

                                    b2.Property<DateTime>("DueDate")
                                        .HasColumnType("timestamp without time zone");

                                    b2.Property<bool?>("Fulfilled")
                                        .HasColumnType("boolean");

                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uuid");

                                    b2.HasKey("RequiredPaymentReservationChangeRequestId");

                                    b2.ToTable("ChangeRequests", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("RequiredPaymentReservationChangeRequestId");
                                });

                            b1.Navigation("Deadline");
                        });

                    b.Navigation("_changeToApply");

                    b.Navigation("_newCost");

                    b.Navigation("_newTravel");

                    b.Navigation("_paymentRequiredToApplyChange");

                    b.Navigation("_reservationToChange");
                });

            modelBuilder.Entity("GroupFlights.Postsale.Domain.Changes.Request.ReservationToChange", b =>
                {
                    b.OwnsOne("GroupFlights.Postsale.Domain.Changes.Outcome.ReservationCost", "CurrentCost", b1 =>
                        {
                            b1.Property<Guid>("ReservationToChangeReservationId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.HasKey("ReservationToChangeReservationId");

                            b1.ToTable("ReservationSnapshots", "postsale");

                            b1.WithOwner()
                                .HasForeignKey("ReservationToChangeReservationId");

                            b1.OwnsOne("GroupFlights.Shared.Types.Money", "RefundableCost", b2 =>
                                {
                                    b2.Property<Guid>("ReservationCostReservationToChangeReservationId")
                                        .HasColumnType("uuid");

                                    b2.Property<decimal>("Amount")
                                        .HasColumnType("numeric");

                                    b2.Property<int>("Currency")
                                        .HasColumnType("integer");

                                    b2.HasKey("ReservationCostReservationToChangeReservationId");

                                    b2.ToTable("ReservationSnapshots", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("ReservationCostReservationToChangeReservationId");
                                });

                            b1.OwnsOne("GroupFlights.Shared.Types.Money", "TotalCost", b2 =>
                                {
                                    b2.Property<Guid>("ReservationCostReservationToChangeReservationId")
                                        .HasColumnType("uuid");

                                    b2.Property<decimal>("Amount")
                                        .HasColumnType("numeric");

                                    b2.Property<int>("Currency")
                                        .HasColumnType("integer");

                                    b2.HasKey("ReservationCostReservationToChangeReservationId");

                                    b2.ToTable("ReservationSnapshots", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("ReservationCostReservationToChangeReservationId");
                                });

                            b1.Navigation("RefundableCost")
                                .IsRequired();

                            b1.Navigation("TotalCost")
                                .IsRequired();
                        });

                    b.OwnsMany("GroupFlights.Postsale.Domain.Changes.Payments.RequiredPayment", "CurrentPayments", b1 =>
                        {
                            b1.Property<Guid>("ReservationToChangeReservationId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<bool>("Payed")
                                .HasColumnType("boolean");

                            b1.Property<Guid>("PaymentId")
                                .HasColumnType("uuid");

                            b1.HasKey("ReservationToChangeReservationId", "Id");

                            b1.ToTable("ReservationSnapshots_CurrentPayments", "postsale");

                            b1.WithOwner()
                                .HasForeignKey("ReservationToChangeReservationId");

                            b1.OwnsOne("GroupFlights.Postsale.Domain.Shared.Deadline", "Deadline", b2 =>
                                {
                                    b2.Property<Guid>("RequiredPaymentReservationToChangeReservationId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("RequiredPaymentId")
                                        .HasColumnType("integer");

                                    b2.Property<DateTime>("DueDate")
                                        .HasColumnType("timestamp without time zone");

                                    b2.Property<bool?>("Fulfilled")
                                        .HasColumnType("boolean");

                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uuid");

                                    b2.HasKey("RequiredPaymentReservationToChangeReservationId", "RequiredPaymentId");

                                    b2.ToTable("ReservationSnapshots_CurrentPayments", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("RequiredPaymentReservationToChangeReservationId", "RequiredPaymentId");
                                });

                            b1.Navigation("Deadline");
                        });

                    b.OwnsMany("GroupFlights.Postsale.Domain.Shared.FlightSegment", "CurrentTravel", b1 =>
                        {
                            b1.Property<Guid>("ReservationToChangeReservationId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp without time zone");

                            b1.HasKey("ReservationToChangeReservationId", "Id");

                            b1.ToTable("ReservationSnapshots_CurrentTravel", "postsale");

                            b1.WithOwner()
                                .HasForeignKey("ReservationToChangeReservationId");

                            b1.OwnsOne("GroupFlights.Postsale.Domain.Shared.FlightTime", "FlightTime", b2 =>
                                {
                                    b2.Property<Guid>("FlightSegmentReservationToChangeReservationId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("FlightSegmentId")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Hours")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Minutes")
                                        .HasColumnType("integer");

                                    b2.HasKey("FlightSegmentReservationToChangeReservationId", "FlightSegmentId");

                                    b2.ToTable("ReservationSnapshots_CurrentTravel", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("FlightSegmentReservationToChangeReservationId", "FlightSegmentId");
                                });

                            b1.OwnsOne("GroupFlights.Shared.Types.Airport", "SourceAirport", b2 =>
                                {
                                    b2.Property<Guid>("FlightSegmentReservationToChangeReservationId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("FlightSegmentId")
                                        .HasColumnType("integer");

                                    b2.Property<string>("City")
                                        .HasColumnType("text");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Country")
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .HasColumnType("text");

                                    b2.HasKey("FlightSegmentReservationToChangeReservationId", "FlightSegmentId");

                                    b2.ToTable("ReservationSnapshots_CurrentTravel", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("FlightSegmentReservationToChangeReservationId", "FlightSegmentId");
                                });

                            b1.OwnsOne("GroupFlights.Shared.Types.Airport", "TargetAirport", b2 =>
                                {
                                    b2.Property<Guid>("FlightSegmentReservationToChangeReservationId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("FlightSegmentId")
                                        .HasColumnType("integer");

                                    b2.Property<string>("City")
                                        .HasColumnType("text");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Country")
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .HasColumnType("text");

                                    b2.HasKey("FlightSegmentReservationToChangeReservationId", "FlightSegmentId");

                                    b2.ToTable("ReservationSnapshots_CurrentTravel", "postsale");

                                    b2.WithOwner()
                                        .HasForeignKey("FlightSegmentReservationToChangeReservationId", "FlightSegmentId");
                                });

                            b1.Navigation("FlightTime");

                            b1.Navigation("SourceAirport");

                            b1.Navigation("TargetAirport");
                        });

                    b.OwnsOne("GroupFlights.Postsale.Domain.Shared.Deadline", "PassengerNamesDeadline", b1 =>
                        {
                            b1.Property<Guid>("ReservationToChangeReservationId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("DueDate")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<bool?>("Fulfilled")
                                .HasColumnType("boolean");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.HasKey("ReservationToChangeReservationId");

                            b1.ToTable("ReservationSnapshots", "postsale");

                            b1.WithOwner()
                                .HasForeignKey("ReservationToChangeReservationId");
                        });

                    b.Navigation("CurrentCost")
                        .IsRequired();

                    b.Navigation("CurrentPayments");

                    b.Navigation("CurrentTravel");

                    b.Navigation("PassengerNamesDeadline");
                });
#pragma warning restore 612, 618
        }
    }
}
