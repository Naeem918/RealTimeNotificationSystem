using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CloudBaseLine.Roles.Dto;
using CloudBaseLine.Users.Dto;

namespace CloudBaseLine.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
