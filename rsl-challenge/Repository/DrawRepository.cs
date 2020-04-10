using System.Collections.Generic;

using rsl_challenge.Models;

namespace rsl_challenge.Repository
{
    public class DrawRepository 
    {
        //Logo replacements
        private const string ozLottoLogoUrl = "ico--circle--ozlotto.png";
        private const string powerballLogoUrl = "ico--circle-powerball.png";
        private const string GoldLottoLogoUrl = "ico--circle-sat-goldlotto.png";
        public static DrawsList HydrateDraws(DrawsList drawsList) {

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
