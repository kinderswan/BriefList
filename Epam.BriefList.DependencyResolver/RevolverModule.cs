using System.Data.Entity;
using Epam.BriefList.DataAccess.API.Interfaces;
using Epam.BriefList.DataAccess.MSSQLProvider;
using Epam.BriefList.DataAccess.MSSQLProvider.Infrastructure;
using Epam.BriefList.DataAccess.MSSQLProvider.Repository;
using Epam.BriefList.Services.API.Interfaces;
using Epam.BriefList.Services.Services;
using Ninject;
using Ninject.Web.Common;

namespace Epam.BriefList.DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<DbContext>().To<EntityModelContext>().InRequestScope();
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            }
            else
            {
                kernel.Bind<DbContext>().To<EntityModelContext>().InSingletonScope();
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            }

            kernel.Bind<IUserProfileRepository>().To<UserProfileRepository>();
            kernel.Bind<IListRepository>().To<ListRepository>();
            kernel.Bind<IItemRepository>().To<ItemRepository>();

            kernel.Bind<IUserProfileService>().To<UserProfileService>();
            kernel.Bind<IListService>().To<ListService>();
            kernel.Bind<IItemService>().To<ItemService>();
        }
    }

}
