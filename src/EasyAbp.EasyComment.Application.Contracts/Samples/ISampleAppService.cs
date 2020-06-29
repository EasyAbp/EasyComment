using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EasyAbp.EasyComment.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
