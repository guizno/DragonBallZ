using System.Text.Json;
using Dragonballz.Models;

namespace Dragonballz.Services;
public class DragonService
{
    private readonly IHttpContextAccessor _session;
    private readonly string guerreiroFile = @"Data\guerreiro.json";
    private readonly string especieFile = @"Data\especie.json";

    public DragonService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }

    public List<Guerreiro> GetGuerreiros()
    {
        PopularSessao();
        var guerreiros = JsonSerializer.Deserialize<List<Guerreiro>>
            (_session.HttpContext.Session.GetString("Guerreiros"));
        return guerreiros;
    }
    
    public List<Especie> GetEspecies()
    {
        PopularSessao();
        var especies = JsonSerializer.Deserialize<List<Especie>>
            (_session.HttpContext.Session.GetString("Especies"));
        return especies;
    }

    public Guerreiro GetGuerreiro(int Numero)
    {
        var guerreiros = GetGuerreiros();
        return guerreiros.Where(p => p.Numero == Numero).FirstOrDefault();
    }

    public DragonballzDto GetDragonballzDto()
    {
        var dragons = new DragonballzDto()
        {
            Guerreiros = GetGuerreiros(),
            Especies = GetEspecies()
        };
        return dragons;
    }

    public DetailsDto GetDetailedDragonballz(int Numero)
    {
        var guerreiros = GetGuerreiros();
        var dragon = new DetailsDto()
        {
            Current = guerreiros.Where(p => p.Numero == Numero).FirstOrDefault(),
            Prior = guerreiros.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < Numero),
            Next = guerreiros.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > Numero),
        };
        return dragon;
    }

    public Especie GetEspecie(string Nome)
    {
        var especies = GetEspecies();
        return especies.Where(t => t.Nome == Nome).FirstOrDefault();
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Especies")))
        {
            _session.HttpContext.Session.SetString("Guerreiros", LerArquivo(guerreiroFile.file));
            _session.HttpContext.Session.SetString("Especies", LerArquivo(especieFile));
        }
    }

    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }
}
