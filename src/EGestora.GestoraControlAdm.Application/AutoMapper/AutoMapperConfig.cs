using AutoMapper;
using System;

namespace EGestora.GestoraControlAdm.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<DomainToViewModelMappingProfile>();
            //    cfg.AddProfile<ViewModelToDomainMappingProfile>();
            //});
            //var mapper = config.CreateMapper();
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
