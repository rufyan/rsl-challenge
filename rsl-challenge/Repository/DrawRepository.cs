using Microsoft.Extensions.Configuration;
using rsl_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rsl_challenge.Repository
{
    public class DrawRepository : IDrawsRepository
    {
        private readonly IConfiguration _config;
        public DrawRepository(IConfiguration config)
        {
            _config = config;
        }
        public DrawsList HydrateDraws(DrawsList drawsList) {
            var ozLottoLogoUrl = _config.GetValue<string>("DrawLogos:OzLotto");
            var powerballLogoUrl = _config.GetValue<string>("DrawLogos:Powerball");
            var GoldLottoLogoUrl = _config.GetValue<string>("DrawLogos:GoldLotto");

            var hydratedDraws = new DrawsList();
            hydratedDraws.Draws = new List<Draw>();

            if (drawsList.Draws.Count > 0 && drawsList.Success)
            {
                foreach (var draw in drawsList.Draws)
                {
                    var newDraw = draw;
                    switch (draw.ProductId) {
                        case "OzLotto":
                            newDraw.DrawLogoUrl = ozLottoLogoUrl;
                        break;
                        case "Powerball":
                            newDraw.DrawLogoUrl = powerballLogoUrl;
                        break;
                        case "TattsLotto": case "GoldLogo":
                            newDraw.DrawLogoUrl = GoldLottoLogoUrl;
                        break;

                    }

                    hydratedDraws.Draws.Add(newDraw);
                }
            }
            return hydratedDraws;
        }
    }
}
