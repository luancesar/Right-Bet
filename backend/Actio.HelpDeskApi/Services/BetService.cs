using Actio.HelpDeskApi.Context;
using Actio.HelpDeskApi.Entity;
using Actio.HelpDeskApi.Models;
using Actio.HelpDeskApi.Repository;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Services
{
    
    public class BetService : IBetService
    {
        private readonly IBetRepository _betRepository;
        private readonly HelpDeskContext _context;
        private readonly IUsuarioRepository _usuarioRepository;

        public BetService(IBetRepository betRepository, HelpDeskContext context, IUsuarioRepository usuarioRepository)
        {
            _betRepository = betRepository;
            _context = context;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Bet(BetModel model)
        {
            try
            {
                var usuarios = await _usuarioRepository.ObterUsuarios();

                var usuario = usuarios.FirstOrDefault();

                var bet = new Bet()
                {
                    Date = DateTime.Now,
                    Stake = Convert.ToDecimal(model.Stake),
                    ODD = Convert.ToDecimal(model.Odd),
                    Green = model.Green,
                };

                bet.Lucro = CalcProfit(bet.Green, bet.Stake, bet.ODD);

                usuario.AtualizarBancaAtual(bet.Lucro);
                bet.Porcentagem = usuario.PorcentagemFaturamento;
                bet.SaldoAtual = usuario.BancaAtual;

                await _betRepository.AddAsync(bet);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        private decimal CalcProfit(bool isGreen, decimal stake, decimal odd)
        {
            if (isGreen)
                return (stake * odd) - stake;
            else
                return stake * -1;
        }
        public async Task<List<BetModel>> GetBets()
        {
            try
            {
                var bets = await _betRepository.GetBets();

                return bets.Select(u => new BetModel
                {
                    Id = u.Id,
                    Date = u.Date,
                    Stake = u.Stake.ToString(),
                    Odd = u.ODD.ToString(),
                    Green = u.Green,
                    Lucro = u.Lucro.ToString(),
                    SaldoAtual = u.SaldoAtual.ToString(),
                    Porcentagem = u.Porcentagem.ToString()
                }).OrderByDescending(b => b.Id).ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var bet = await _betRepository.GetById(id);
                var bets = await _betRepository.GetBets();
                var usuarios = await _usuarioRepository.ObterUsuarios();

                var usuario = usuarios.FirstOrDefault();

                await _betRepository.DeleteAsync(bet);

                usuario.RecalculateValues(bets);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public async Task<byte[]> DownloadFile(string endereco)
        {
            var uri = new Uri(new Uri(endereco), "/#/app/cadastro/relatorio");
           
            using (var browser = await GetBrowser())
            {
                using (var page = await browser.NewPageAsync())
                {
                    var cookies = new List<CookieParam>();

                    page.DefaultTimeout = 600000;
                    await page.SetViewportAsync(new ViewPortOptions() { Width = 1250 });
                    await page.SetCookieAsync(cookies.ToArray());
                    await page.GoToAsync(uri.ToString());
                    await page.WaitForTimeoutAsync(10000);

                    var image = await page.ScreenshotDataAsync(new ScreenshotOptions() { FullPage = true });

                    return image;
                }
            }
        }

        private async Task<Browser> GetBrowser()
        {
            return await Puppeteer.LaunchAsync(new LaunchOptions
            {
               
                Headless = true,
                ExecutablePath = "C:/Program Files (x86)/Google/Chrome/Application/chrome.exe"
            });
        }

    }
}
