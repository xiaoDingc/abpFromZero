using Shouldly;
using Xunit;
using ZL.Poem.Application.Poems;

namespace ZL.PoemApplication.Test
{
    public class PoemApplicationTest:PoemTestBase
    {
        private  readonly  IPoetAppService _poetAppService;

        public PoemApplicationTest()
        {
            _poetAppService=Resolve<IPoetAppService>();
        }

        [Fact]
        public  void GetPoets_Test()
        {
            //Act 
            var output=_poetAppService.GetPagedPoets(new PagedResultRequestDto(){MaxResultCount = 10,SkipCount = 0});

            //Assert
            output.Items.Count.ShouldBe(2);
        }
    }
}