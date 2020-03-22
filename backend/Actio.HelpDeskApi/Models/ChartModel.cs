using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Models
{

    public class ChartModel
    {
        public decimal[] Odds { get; set; }
        
        public BetChartModel[] Bets { get; set; }

    };

    public class BetChartModel
    {
        public decimal Faturamento { get; set; }
        public bool Green { get; set; }
    }


}

