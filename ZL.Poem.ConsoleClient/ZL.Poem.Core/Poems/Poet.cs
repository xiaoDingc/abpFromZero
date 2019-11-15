using System.Collections.Generic;
using Abp.Domain.Entities;

namespace ZL.Poem.Core.Poems
{
    /// <summary>
    /// 诗人类
    /// </summary>
    public class Poet : Entity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 写的诗
        /// </summary>
        public virtual ICollection<Poem> Poems { get; set; }
    }
}