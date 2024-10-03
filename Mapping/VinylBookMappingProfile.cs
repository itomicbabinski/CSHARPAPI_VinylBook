using System.Text.RegularExpressions;
using AutoMapper;
using CSHARPAPI_VinylBook.Models;
using CSHARPAPI_VinylBook.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSHARPAPI_VinylBook.Mapping
{
    public class VinylBookMappingProfile : Profile
    {
        public VinylBookMappingProfile()
        {
            // kreiramo mapiranja: izvor, odredište
            CreateMap<User, UserDTORead>();
            CreateMap<UserDTOInsertUpdate, User>();

            CreateMap<Album, AlbumDTORead>();
            CreateMap<AlbumDTOInsertUpdate, Album>();

            CreateMap<RecordCopy, RecordCopyDTORead>()
               .ForMember(
                 dest => dest.UserFirstName,
                 opt => opt.MapFrom(src => src.User.Uname)
               );
            CreateMap<RecordCopy, RecordCopyDTORead>()
                .ForMember(
                    dest => dest.UserLastName,
                    opt => opt.MapFrom(src => src.User.Ulastname)
                );
            CreateMap<RecordCopy, RecordCopyDTORead>()
                .ForMember(
                    dest => dest.AlbumTitle,
                    opt => opt.MapFrom(src => src.Album.Title)
                );
            CreateMap<RecordCopy, RecordCopyDTORead>()
                .ForMember(
                    dest => dest.AlbumArtist,
                    opt => opt.MapFrom(src => src.Album.Artist)
                );

            CreateMap<RecordCopy, RecordCopyDTOInsertUpdate>()
                .ForMember(
                    dest => dest.AlbumId,
                    opt => opt.MapFrom(src => src.Album.Id)
                );
            CreateMap<RecordCopy, RecordCopyDTOInsertUpdate>()
                .ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.User.Id)
                );
            CreateMap<RecordCopyDTOInsertUpdate, RecordCopy>();

        }
    }
}
