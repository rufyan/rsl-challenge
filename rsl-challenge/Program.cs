using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace rsl_challenge
{
    //public class theDraws {
    //    public List<Draw> Draws { get; set; }
    //    public string ErrorInfo { get; set; }
    //    public bool Success { get; set; }
    //}

    //public class DrawMeta
    //{
    //    public string ProductId { get; set; }
    //    public int DrawNumber { get; set; }
    //    public DateTime DrawDate { get; set; }
    //    public string DrawDisplayName { get; set; }
    //    public string DrawLogoUrl { get; set; }
    //}

    //public class Draw : DrawMeta {
    //    public string DrawType { get; set; }
    //    public decimal Div1Amount { get; set; }
    //    public bool IsDiv1Estimated { get; set; }
    //    public bool IsDiv1Unknown { get; set; }
    //    public DateTime DrawCloseDateTimeUTC { get; set; }
    //}

    //public class LotteryResults {
    //    public List<LottResult> DrawResults { get; set;}
    //}

    //public class LotteryResult : DrawMeta
    //{
    //    public List<int> PrimaryNumbers { get; set; }
    //    public List<int> SecondaryNumbers { get; set; }
    //    public string TicketNumbers { get; set; }
    //    public List<Dividend> Dividends { get; set; }
    //}

    //public enum PoolTransferType {
    //    NONE,
    //    TO_DRAW
    //}

    //public class Dividend
    //{
    //    public int Division { get; set; }
    //    public int BlocNumberOfWinners { get; set; }
    //    public decimal BlocDividend { get; set; }
    //    public string CompanyId { get; set; }
    //    public int CompanyNumberOfWinners { get; set; }
    //    public decimal CompanyDividend { get; set; }
    //    public int PoolTransferredTo { get; set; }
    //}

public class Program
    {

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
           // HitApi();
        }

       

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        
    }
}
