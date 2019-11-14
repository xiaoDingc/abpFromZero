using System.Collections.Generic;
using Abp.Domain.Entities;

namespace ZL.Poem.Core.Poems
{
    public class Category:Entity
    {
         /// <summary>
        /// 分类名称
        /// </summary>
        public virtual string CategoryName { get; set; }

        /// <summary>
        /// 该分类中包含的诗
        /// </summary>
        public virtual ICollection<CategoryPoem> CategoryPoems { get; set; }
    }
}