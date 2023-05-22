namespace Dragonballz.Models;
public class Guerreiro
{
   public string Nome { get; set; }
   public string Descricao { get; set; }
   public List<string> Especie { get; set; }
   public double Altura { get; set; }
   public double Peso { get; set; }
   public string Imagem { get; set; }     

   public Guerreiro()
   {
        Especie = new List<string>();
   }

}

