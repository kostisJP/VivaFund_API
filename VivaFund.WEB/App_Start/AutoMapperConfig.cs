using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VivaFund.DomainModels;
using VivaFund.ViewModels;

namespace VivaFund.WEB.App_Start
{
    public class AutoMapperConfig: AutoMapper.Profile
    {
        public AutoMapperConfig()
        {
            Mapper.CreateMap<Project, ProjectViewModel>();
            Mapper.CreateMap<Reward, RewardViewModel>();
            Mapper.CreateMap<Donation, DonationViewModel>();
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Project, ProjectViewModel>();
            //    cfg.CreateMap<Donation, ProjectViewModel>();
            //});

            //IMapper mapper = config.CreateMapper();
        }

        public static void RegisterMappings()
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Project, ProjectViewModel>();
            //    cfg.CreateMap<Donation, ProjectViewModel>();
            //});

            //IMapper mapper = config.CreateMapper();

            //var source = new Source();
            //var dest = mapper.Map<Source, Dest>(source);

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMissingTypeMaps = true;
            //    cfg.CreateMap<Project, ProjectViewModel>();
            //    cfg.CreateMap<Donation, ProjectViewModel>();
            //});
            //Mapper.AssertConfigurationIsValid();

        }
    }
}