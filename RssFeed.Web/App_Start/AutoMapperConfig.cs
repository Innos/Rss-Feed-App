namespace RssFeed.Web
{
    using AutoMapper;
    using AutoMapper.Configuration;

    using RssFeed.Web.Models;
    using RssFeed.Data.Models;

    public class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration { get; private set; } 

        public static void RegisterMappings()
        {
            // Maps for all Automapper bindings
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<PersonalFeedInputModel, PersonalFeed>();
            cfg.CreateMap<PersonalFeed, PersonalFeedInputModel>()
                .ForMember(m => m.Url, opt => opt.MapFrom(e => e.Feed.Url));
            cfg.CreateMap<PersonalFeed, PersonalFeedViewModel>()
                .ForMember(m => m.UnreadArticlesCount, opt => opt.MapFrom(e => e.UnreadArticles.Count));

            MapperConfiguration = new MapperConfiguration(cfg);

            Mapper.Initialize(cfg);
        }
    }
}