using rsl_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rsl_challenge.Repository
{
    public interface IDrawsRepository
    {
        DrawsList HydrateDraws(DrawsList drawsList);
    }
}
