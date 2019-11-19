using Abp.Application.Services.Dto;

namespace ZL.Poem.Application.Poems
{
    public class SearchPoetDto:PagedResultRequestDto
    {
        public  string Keyword {get;set;}
    }
}