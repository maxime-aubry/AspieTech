using AspieTech.Logger.DataAccessLayer.Entities;
using AutoMapper;
using NLog;

namespace AspieTech.Logger.Mapping
{
    public class MappingProfile : Profile
    {
        #region Private properties

        #endregion

        #region Constructors
        public MappingProfile()
        {
            this.CreateMap<LogEventInfo, LogEventInfoEntity>()
                //.ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
                //.ForMember(dest => dest.ExceptionType, opt => opt.MapFrom(src => (src.Exception != null) ? src.Exception.GetType().Name : null))
                //.ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                //.ForMember(dest => dest.StackTrace, opt => opt.MapFrom(src => src.HasStackTrace ? src.StackTrace : null))
                //.ForMember(dest => dest.InnerException, opt => opt.MapFrom(src => (src.Exception != null) ? src.Exception.InnerException : null))
                //.ForMember(dest => dest.AdditionalInfo, opt => opt.MapFrom(src => (src.Exception != null) ? src.Exception.Message : null))
                //.ForMember(dest => dest.LoggedOnDate, opt => opt.MapFrom(src => src.TimeStamp))
                //.ForMember(dest => dest.LogID, opt => opt.MapFrom(src => Guid.Parse(src.Properties["ID"].ToString())))
                //.ForMember(dest => dest.ResourceType, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Properties["ResourceType"].ToString())))
                //.ForMember(dest => dest.ResourceCode, opt => opt.MapFrom(src => src.Properties["ResourceCode"].ToString()))
                //.ForMember(dest => dest.Args, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Properties["Args"].ToString())))
                ;

            //this.CreateMap<LogEventInfoEntity, LogEventInfo>()
            //    .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
            //    //.ForMember(dest => dest.ex, opt => opt.MapFrom(src => src.Level))
            //    ;

        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods

        #endregion

        #region Private methods

        #endregion
    }
}