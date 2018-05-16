using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudBaseLine
{
  public   class BaseLineDomainServiceBase: DomainService
    {
        protected BaseLineDomainServiceBase()
        {
            LocalizationSourceName = CloudBaseLineConsts.LocalizationSourceName;
        }
    }
}
