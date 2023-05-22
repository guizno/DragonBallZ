using Dragonballz.Models;
namespace Dragonballz.Services;

public interface IDragonService
{
    List<Guerreiro> GetGuerreiros();
    List<Especie> GetEspecies();
    Guerreiro GetGuerreiro (int Numero);
    DragonballzDto GetDragonballzDto();
    DetailsDto GetDetailedGuerreiro(int Numero);
    Especie GetEspecie(string Nome);
}
