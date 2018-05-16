using System.Threading.Tasks;
using Abp.Application.Services;
using CloudBaseLine.Sessions.Dto;

namespace CloudBaseLine.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
