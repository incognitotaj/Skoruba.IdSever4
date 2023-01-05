using System.Collections.Generic;

namespace IdSever4.Admin.Api.Dtos.Roles
{
    public class RoleClaimsApiDto<TKey>
    {
        public RoleClaimsApiDto()
        {
            Claims = new List<RoleClaimApiDto<TKey>>();
        }

        public List<RoleClaimApiDto<TKey>> Claims { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }
}







