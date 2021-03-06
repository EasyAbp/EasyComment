﻿using EasyAbp.EasyComment.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.EasyComment
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(EasyCommentEntityFrameworkCoreTestModule)
        )]
    public class EasyCommentDomainTestModule : AbpModule
    {
        
    }
}
