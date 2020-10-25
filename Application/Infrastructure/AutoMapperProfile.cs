using Application.Dtos.Account.Requests;
using Application.Dtos.Account.Responses;
using Application.Dtos.Admin.Requests;
using Application.Dtos.Admin.Responses;
using Application.Dtos.Logs.Responses;
using AutoMapper;
using Domain.Models.Entities;
using System;
using System.Globalization;
using System.IO;
using Application.Dtos.Auth.Responses;
using Application.Dtos.Maintenance.Requests;
using Application.Dtos.Maintenance.Responses;
using Application.Dtos.Message.Responses;
using Application.Dtos.Review.Responses;
using Application.Dtos.Flat.Responses;
using Domain.Models;
using Application.Dtos.Room.Responses;
using Application.Dtos.Report.Responses;

namespace Application.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForAuth();
            MapsForAccount();
            MapsForAdmin();
            MapsForLogs();
            MapsForMaintenance();
            MapsForMessage();
            //MapsForReview();
            //MapsForAddress();
            //MapsForDocument();
            MapsForFlat();
            //MapsForFlatInformation();
            //MapsForPayment();
            MapsForReport();
            MapsForRoom();
            //MapsForTenancy();
        }

        private void MapsForTenancy()
        {
            throw new NotImplementedException();
        }

        private void MapsForRoom()
        {
            CreateMap<Room, RoomForGetRoomsResponse>();
        }

        private void MapsForReport()
        {
            CreateMap<Report, ReportForGetReportsResponse>();
        }

        private void MapsForPayment()
        {
            throw new NotImplementedException();
        }

        private void MapsForFlatInformation()
        {
            throw new NotImplementedException();
        }

        private void MapsForReview()
        {
            throw new NotImplementedException();
        }

        private void MapsForAddress()
        {
            throw new NotImplementedException();
        }

        private void MapsForDocument()
        {
            throw new NotImplementedException();
        }

        private void MapsForFlat()
        {
            CreateMap<Flat, FlatForGetFlatsResponse>();
            CreateMap<Address, AddressForFlatForGetFlatsResponse>();
        }

        private void MapsForAddresses()
        {
            throw new NotImplementedException();
        }

        private void MapsForReviews()
        {
            CreateMap<Review, ReviewForGetUserReviewsResponse>();
        }

        /// <summary>
        /// Mapy dla kontrolera Maintenance
        /// </summary>
        private void MapsForMaintenance()
        {
            CreateMap<CreateMessageRequest, MaintenanceMessage>();
            CreateMap<MaintenanceMessage, CreateMessageResponse>();

            CreateMap<MaintenanceMessage, GetMessageResponse>();

            CreateMap<MaintenanceMessage, MessageForGetAllMessagesResponse>();

            CreateMap<MaintenanceMessage, MessageForGetUpcomingMessagesResponse>();

            CreateMap<MaintenanceMessage, MessageForGetCurrentMessagesResponse>();

            CreateMap<UpdateMessageRequest, MaintenanceMessage>();
            CreateMap<MaintenanceMessage, UpdateMessageResponse>();
        }

        /// <summary>
        /// Mapy dla kontrolera Admin
        /// </summary>
        private void MapsForAdmin()
        {
            CreateMap<ApplicationUser, Dtos.Admin.Responses.UserForGetUsersResponse>();

            CreateMap<ApplicationUser, GetUserResponse>();

            CreateMap<ApplicationUser, CreateUserResponse>();

            CreateMap<UpdateUserRequest, ApplicationUser>();
            CreateMap<ApplicationUser, UpdateUserResponse>();
        }

        /// <summary>
        /// Mapy dla kontrolera Account
        /// </summary>
        private void MapsForAccount()
        {
            CreateMap<ApplicationUser, GetAccountDetailsResponse>();

            CreateMap<UpdateAccountDetailsRequest, ApplicationUser>();
            CreateMap<ApplicationUser, UpdateAccountDetailsResponse>();

            CreateMap<ApplicationUser, Dtos.Account.Responses.UserForGetUsersResponse>();

        }

        /// <summary>
        /// Mapy dla kontrolera Auth
        /// </summary>
        private void MapsForAuth()
        {
            CreateMap<ApplicationUser, RegisterResponse>();
        }

        /// <summary>
        /// Mapy dla kontrolera Logs
        /// </summary>
        private void MapsForLogs()
        {
            CreateMap<FileInfo, LogForGetLogsFilesResponse>()
                .ForMember(log => log.SizeInKb, opt => opt.MapFrom(fileInfo => Math.Round((double)(fileInfo.Length / 1024), 2)))
                .ForMember(log => log.Date, opt => opt.MapFrom(fileInfo => DateTime.ParseExact(fileInfo.Name.Substring(3, 8), "yyyyMMdd", CultureInfo.InvariantCulture)))
                .ForMember(log => log.Name, opt => opt.MapFrom(fileInfo => Path.GetFileNameWithoutExtension(fileInfo.Name)));
        }

        /// <summary>
        /// Mapy dla kontrolera Message
        /// </summary>
        private void MapsForMessage()
        {
            CreateMap<Message, MessageForGetConversationMessagesResponse>();

            CreateMap<Message, MessageForConversationForGetConversationsResponse>();
            CreateMap<ApplicationUser, UserForConversationForGetConversationsResponse>();
        }
    }
}