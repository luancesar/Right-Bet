using Actio.HelpDeskApi.Context;
using Actio.HelpDeskApi.Entity;
using Actio.HelpDeskApi.Models;
using Actio.HelpDeskApi.Repository;
using CryptSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly HelpDeskContext _context;
        private readonly IBetService _betService;

        public UsuarioService(IUsuarioRepository usuarioRepository, HelpDeskContext context, IBetService betService)
        {
            _usuarioRepository = usuarioRepository;
            _context = context;
            _betService = betService;
        }

        public async Task<bool> AutenticarUsuario(string userName, string password)
        {
            try
            {
                var resposta = await _usuarioRepository.AutenticarUsuario(userName, password);
                return resposta;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public async Task<bool> RegistrarUsuario(UserModel user)
        {
            var usuario = new Usuario(user.Login);

            usuario.Nome = user.Nome;
            //usuario.Senha = Crypter.MD5.Crypt(user.Senha);
            usuario.Email = user.Email;
            usuario.Matricula = user.Matricula;
            usuario.Telefone = user.Telefone;
            usuario.BancaInicial =  Convert.ToDecimal(user.BancaInicial);
            usuario.BancaAtual =  Convert.ToDecimal(user.BancaInicial);


            try
            {
                await _usuarioRepository.AddAsync(usuario);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public async Task<UserModel[]> ObterUsuarios()
        {
            try
            {
                var usuarios = await _usuarioRepository.ObterUsuarios();

                return usuarios.Select(u => new UserModel {
                    Id = u.Id, 
                    Nome = u.Nome, 
                    Email = u.Email,
                    BancaInicial = "R$ "+ u.BancaAtual.ToString()}).ToArray();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }
        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var user = await _usuarioRepository.GetById(userId);

                await _usuarioRepository.DeleteAsync(user);

                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public async Task<ReportModel> GetReportModel()
        {
            try
            {
                var usuarios = await _usuarioRepository.ObterUsuarios();
                var user = usuarios.FirstOrDefault();

                var bets = await _betService.GetBets();
                
                var betsDay = bets.Where(b => b.Date.Day == DateTime.Now.Day && b.Date.Month == DateTime.Now.Month && b.Date.Year == DateTime.Now.Year);
                var betsMonth = bets.Where(b => b.Date.Month == DateTime.Now.Month && b.Date.Year == DateTime.Now.Year);

                var entradas = Convert.ToDecimal(betsDay.Count());
                var greens = Convert.ToDecimal(betsDay.Where(b =>  b.Green).Count());
                var rentabilidade = betsDay.Sum(b => Convert.ToDecimal(b.Lucro));
                var parcial = betsMonth.Sum(b => Convert.ToDecimal(b.Lucro));

                var report = new ReportModel()
                {
                    BancaAtual = user.BancaAtual,
                    BancaInicial = user.BancaInicial,
                    Entradas = (int)entradas,
                    PorcentagemGreen = entradas>0 ? (greens/entradas)*100 : (decimal)0.5,
                    Rentabilidade = rentabilidade,
                    Parcial = parcial
                };

                return report;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

    }
}
