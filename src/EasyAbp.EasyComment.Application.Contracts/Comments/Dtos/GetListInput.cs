using Volo.Abp.Application.Dtos;

namespace EasyAbp.EasyComment.Comments.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto
    {
        public string ItemType { get; set; }
        public string ItemKey { get; set; }
    }
}