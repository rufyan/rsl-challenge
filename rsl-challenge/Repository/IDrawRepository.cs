using rsl_challenge.Models;

namespace rsl_challenge.Repository
{
    public interface IDrawRepository
    {
        DrawsList HydrateDraws(DrawsList drawsList);
    }
}
