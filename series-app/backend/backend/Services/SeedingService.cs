using backend.Data;
using backend.Models;
using backend.Models.Enum;
using System.Linq;

namespace backend.Services
{
    public class SeedingService
    {
        private DataContext _context;

        public SeedingService(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Serie.Any())
            {
                return;
            }
            else
            {
                string S1Descricao = "Em 2030, o arquiteto Ted Mosby(Josh Radnor) conta a história sobre como conheceu " +
                                     "a mãe dos seus filhos.Ele volta no tempo para 2005, relembrando suas aventuras " +
                                     "amorosas em Nova York e a busca pela mulher dos seus sonhos.";
                Serie s1 = new Serie(Genero.Comedia, "How I met Your Mother", S1Descricao, 2005);

                string S2Descricao = "Seis jovens são unidos por laços familiares, românticos e, principalmente, de amizade, " +
                                     "enquanto tentam vingar em Nova York. Rachel é a garota mimada que deixa o noivo no " +
                                     "altar para viver com a amiga dos tempos de escola Monica, sistemática e apaixonada " +
                                     "pela culinária. Monica é irmã de Ross, um paleontólogo que é abandonado pela esposa, " +
                                     "que descobriu ser lésbica. Do outro lado do corredor do apartamento de Monica e " +
                                     "Rachel, moram Joey, um ator frustrado, e Chandler, de profissão misteriosa. A turma " +
                                     "é completa pela exótica Phoebe.";
                Serie s2 = new Serie(Genero.Comedia, "Friends", S2Descricao, 1994);

                string S3Descricao = "Situada 200 anos no futuro, The Expanse narra a história de um tempo em que a " +
                                     "humanidade já colonizou o sistema solar. A história começa quando o desaparecimento " +
                                     "de uma mulher leva um detetive (Thomas Jane) e o capitão de uma nave espacial " +
                                     "(Steven Strait) a trabalharem juntos, mas eles acabam entrando em uma corrida para " +
                                     "revelar uma conspiração que pode ser a maior e mais perigosa da história da " +
                                     "humanidade."; ;
                Serie s3 = new Serie(Genero.Ficcao, "The Expanse", S3Descricao, 2015);

                string S4Descricao = "Como era o mundo antes do início da epidemia de \"The Walking Dead\"? " +
                                     "Ambientada em Los Angeles, Fear The Walking Dead narra o início da contaminação, através " +
                                     "dos olhos de uma família tentando sobreviver. A orientadora pedagógica Madison Clark " +
                                     "(Kim Dickens) precisa cuidar dos dois filhos - o viciado Nick (Frank Dillane) " +
                                     "e a adolescente Alicia (Alycia Debnam-Carey). Já seu marido, o professor de inglês Travis " +
                                     "(Cliff Curtis), decide partir em busca de Chris (Lorenzo James Henrie), seu filho do " +
                                     "primeiro casamento, e da ex-esposa Liza Ortiz (Elizabeth Rodriguez). À medida que a " +
                                     "civilização colapsa ao seu redor, eles não têm outra opção a não ser se reinventar, " +
                                     "aprender novas habilidades e adotar novas atitudes.";
                Serie s4 = new Serie(Genero.Terror, "Fear the Walking Dead", S4Descricao, 2015);

                _context.Serie.AddRange(s1, s2, s3, s4);

                _context.SaveChanges();
            }
        }
    }
}
