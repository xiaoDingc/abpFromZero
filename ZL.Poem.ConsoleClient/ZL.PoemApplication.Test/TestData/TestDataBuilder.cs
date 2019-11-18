using System.Collections.Generic;
using ZL.Poem.Core.Poems;
using ZL.Poem.EF.EntityFramework;

namespace ZL.PoemApplication.Test.TestData
{

    public class TestDataBuilder
    {
        private readonly PoemGameDbContext _poemGameDbContext;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public TestDataBuilder(PoemGameDbContext poemGameDbContext)
        {
            _poemGameDbContext = poemGameDbContext;
        }

        public void Build()
        {
            _poemGameDbContext.Poets.AddRange(new List<Poet>()
            {
                new Poet(){Name = "libai"},
                new Poet(){Name = "dupu"},
            });
        }
    }
}