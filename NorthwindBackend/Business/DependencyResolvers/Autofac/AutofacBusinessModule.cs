using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProuctDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<OrganizasyonManager>().As<IOrganizasyonService>();
            builder.RegisterType<EfOrganizasyonDal>().As<IOrganizasyonDal>();

            builder.RegisterType<EtkinlikManager>().As<IEtkinlikService>();
            builder.RegisterType<EfEtkinlikDal>().As<IEtkinlikDal>();

            builder.RegisterType<FirmaManager>().As<IFirmaService>();
            builder.RegisterType<EfFirmaDal>().As<IFirmaDal>();

            builder.RegisterType<EtkinlikFirmaManager>().As<IEtkinlikFirmaService>();
            builder.RegisterType<EfEtkinlikFirmaDal>().As<IEtkinlikFirmaDal>();

            builder.RegisterType<FirmaCalisaniManager>().As<IFirmaCalisaniService>();
            builder.RegisterType<EfFirmaCalisaniDal>().As<IFirmaCalisaniDal>();


        }
    }
}
