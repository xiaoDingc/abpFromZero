using Abp.TestBase;
using System;
using System.Threading.Tasks;
using ZL.Poem.EF.EntityFramework;
using ZL.PoemApplication.Test.TestData;

namespace ZL.PoemApplication.Test
{
    public  class PoemTestBase : AbpIntegratedTestBase<PoemApplicationTestModule>
    {
        public PoemTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        private void UsingDbContext(Action<PoemGameDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<PoemGameDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        private T UsingDbContext<T>(Func<PoemGameDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<PoemGameDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        private async Task UsingDbContextAsync(Func<PoemGameDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<PoemGameDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        private async Task<T> UsingDbContextAsync<T>(Func<PoemGameDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<PoemGameDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
