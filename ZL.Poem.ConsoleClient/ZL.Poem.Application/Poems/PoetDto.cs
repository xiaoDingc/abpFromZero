using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using ZL.Poem.Core.Poems;

namespace ZL.Poem.Application.Poems
{
    [AutoMapFrom(typeof(Poet))]
    public class PoetDto:EntityDto
    {
         /// <summary>
        /// 姓名
        /// </summary>
        public  string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public  string Description { get; set; }
    }
}