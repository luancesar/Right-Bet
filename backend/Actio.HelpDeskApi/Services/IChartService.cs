using Actio.HelpDeskApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Services
{
    public interface IChartService
    {
        Task<ChartModel> GetModel();

    }
}
