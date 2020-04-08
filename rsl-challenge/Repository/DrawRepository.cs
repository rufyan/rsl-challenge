using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using rsl_challenge.Models;

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
            //Logo replacements
            var ozLottoLogoUrl = _config.GetValue<string>("DrawLogos:OzLotto");
            var powerballLogoUrl = _config.GetValue<string>("DrawLogos:Powerball");
            var GoldLottoLogoUrl = _config.GetValue<string>("DrawLogos:GoldLotto");

            var hydratedDraws = new DrawsList();
            hydratedDraws.Draws = new List<Draw>();

            if (drawsList !=null && drawsList.Draws.Count > 0 && drawsList.Success)
            {
                foreach (var draw in drawsList.Draws)
                {
                    var newDraw = draw;
                    //For the draws required on the challenge, replace the logoUrl with a local one
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
