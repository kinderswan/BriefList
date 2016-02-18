using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;
using System.Data.Entity;
using DAL.Repository;
using BLL.Services;
using Ninject.Web.Common;
using Ninject;
using DAL;
using DAL.Infrastructure;

namespace DependencyResolver
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
            kernel.Bind<ISubItemRepository>().To<SubItemRepository>();
            kernel.Bind<IListRepository>().To<ListRepository>();
            kernel.Bind<IItemRepository>().To<ItemRepository>();
            kernel.Bind<IItemFileRepository>().To<ItemFileRepository>();
            kernel.Bind<ICommentsRepository>().To<CommentsRepository>();

            kernel.Bind<IUserProfileService>().To<UserProfileService>();
            kernel.Bind<ISubItemService>().To<SubItemService>();
            kernel.Bind<IListService>().To<ListService>();
            kernel.Bind<IItemService>().To<ItemService>();
            kernel.Bind<IItemFileService>().To<ItemFileService>();
            kernel.Bind<ICommentsService>().To<CommentsService>();
        }
    }

}
