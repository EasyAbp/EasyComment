using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.EasyComment.Comments.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto
    {
        [Required]
        public string ItemType { get; set; }
        
        [Required]
        public string ItemKey { get; set; }
    }
}