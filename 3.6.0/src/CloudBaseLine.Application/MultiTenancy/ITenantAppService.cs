using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CloudBaseLine.MultiTenancy.Dto;

namespace CloudBaseLine.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
