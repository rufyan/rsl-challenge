using System;
using System.Collections.Generic;

namespace rsl_challenge.Models
{
    public class DrawsList : IDrawsList
    {
        public List<Draw> Draws { get; set; }
        public string ErrorInfo { get; set; }
        public bool Success { get; set; }
    }

    public interface IDrawsList
    {
        List<Draw> Draws { get; set; }
        string ErrorInfo { get; set; }
        bool Success { get; set; }
    }

}
