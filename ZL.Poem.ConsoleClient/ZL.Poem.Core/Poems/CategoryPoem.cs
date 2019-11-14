using Abp.Domain.Entities;

namespace ZL.Poem.Core.Poems
{
    /// <summary>
    /// 诗分类
    /// </summary>
    public class CategoryPoem:Entity
    {
        public virtual int CategoryId { get; set; }

        public virtual int PoemId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Poem Poem { get; set; }
    }
}