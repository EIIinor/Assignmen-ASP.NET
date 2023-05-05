﻿using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;

namespace Assignmen_ASP.NET.Helpers.Repositories;

public class TagRepository : Repository<DataContext, TagEntity>
{
    public TagRepository(DataContext context) : base(context)
    {
    }
}



//public class TagRepository : Repository<TagEntity>
//{
//    public TagRepository(IdentityContext context) : base(context)
//    {
//    }
//}
