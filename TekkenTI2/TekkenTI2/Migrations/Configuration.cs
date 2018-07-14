namespace TekkenTI2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TekkenTI2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TekkenTI2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TekkenTI2.Models.ApplicationDbContext context)
        {


            // add UTILIZADORES 

            var utilizadores = new List<Utilizadores> {
                new Utilizadores {ID=1, UserName ="tiago-rafael_98@hotmail.com", NomeCompleto = "Rafael André Campos Gonçalves", DataNascimento = new DateTime(1996,5,3),  Email = "tiago-rafael_98@hotmail.com"},
                new Utilizadores {ID=2, UserName ="racggoncalves@gmail.com", NomeCompleto = "Tiago Jorge Campos Gonçalves", Email = "tjorge@gmail.com", DataNascimento = new DateTime(1992,4,11)},
                new Utilizadores {ID=3, UserName ="racggoncalves@gmail.com", NomeCompleto = "Simão Pedro Oliveira Moleiro", Email = "symao96@gmail.com", DataNascimento = new DateTime(1996,10,2)},
                new Utilizadores {ID=4, UserName ="racggoncalves@gmail.com", NomeCompleto = "Beatriz Bangurá Okica de Sá", Email = "beatrizbokica@gmail.com", DataNascimento = new DateTime(1995,7,2)},
                new Utilizadores {ID=5, UserName ="racggoncalves@gmail.com" , NomeCompleto = "Patricia Sofia Margalhães Faustino", Email = "patricia.sofia.faustino@gmail.com", DataNascimento = new DateTime(1995,10,2)},
                new Utilizadores {ID=6, UserName ="racggoncalves@gmail.com", NomeCompleto = "Marta Andreia Campos Ribeiro", Email = "Mandreia@gmail.com", DataNascimento = new DateTime(1997,8,22)},
            };

            utilizadores.ForEach(dd => context.Utilizadores.AddOrUpdate(d => d.ID, dd));
            context.SaveChanges();



            // adiciona PLATAFORMAS

            var plataformas = new List<Plataformas> {
                new Plataformas {ID=1, Jogo="Tekken", Plataforma="Arcade", Ano="1994"},
                new Plataformas {ID=2, Jogo="Tekken", Plataforma="PlayStation", Ano="1995"},
                new Plataformas {ID=3, Jogo="Tekken 2", Plataforma="Arcade", Ano="1995"},
                new Plataformas {ID=4, Jogo="Tekken 2", Plataforma="PlayStation", Ano="1996"},
                new Plataformas {ID=5, Jogo="Tekken 3", Plataforma="Arcade", Ano="1997"},
                new Plataformas {ID=6, Jogo="Tekken 3", Plataforma="PlayStation", Ano="1998"},
                new Plataformas {ID=7, Jogo="Tekken 4", Plataforma="Arcade", Ano="2001"},
                new Plataformas {ID=8, Jogo="Tekken 4", Plataforma="PlayStation 2", Ano="2002"},
                new Plataformas {ID=9, Jogo="Tekken 5", Plataforma="Arcade", Ano="2004"},
                new Plataformas {ID=10, Jogo="Tekken 5", Plataforma="PlayStation 2", Ano="2005"},
                new Plataformas {ID=11, Jogo="Tekken 5: Dark Resurrection", Plataforma="Arcade", Ano="2005"},
                new Plataformas {ID=12, Jogo="Tekken 5: Dark Resurrection", Plataforma="PlayStation Portable", Ano="2006"},
                new Plataformas {ID=13, Jogo="Tekken 6", Plataforma="Arcade", Ano="2007"},
                new Plataformas {ID=14, Jogo="Tekken 6", Plataforma="PlayStation 3", Ano="2009"},
                new Plataformas {ID=15, Jogo="Tekken 6", Plataforma="Xbox 360", Ano="2009"},
                new Plataformas {ID=16, Jogo="Tekken 6: Bloodline Rebellion", Plataforma="Arcade", Ano="2008"},
                new Plataformas {ID=17, Jogo="Tekken 6: Bloodline Rebellion", Plataforma="PlayStation 3", Ano="2009"},
                new Plataformas {ID=18, Jogo="Tekken 6: Bloodline Rebellion", Plataforma="Xbox 360", Ano="2009"},
                new Plataformas {ID=19, Jogo="Tekken 6: Bloodline Rebellion", Plataforma="PlayStation Portable", Ano="2009"},
                new Plataformas {ID=20, Jogo="Tekken 7", Plataforma="Arcade", Ano="2015"},
                new Plataformas {ID=21, Jogo="Tekken 7", Plataforma="PlayStation 4", Ano="2017"},
                new Plataformas {ID=22, Jogo="Tekken 7", Plataforma="Xbox One", Ano="2017"},
                new Plataformas {ID=23, Jogo="Tekken 7", Plataforma="Microsoft Windows", Ano="2017"},
                new Plataformas {ID=24, Jogo="Tekken Tag Tournament", Plataforma="Arcade", Ano="1999"},
                new Plataformas {ID=25, Jogo="Tekken Tag Tournament", Plataforma="PlayStation 2", Ano="2000"},
                new Plataformas {ID=26, Jogo="Tekken Tag Tournament 2", Plataforma="Arcade", Ano="2011"},
                new Plataformas {ID=27, Jogo="Tekken Tag Tournament 2", Plataforma="PlayStation 3", Ano="2012"},
                new Plataformas {ID=28, Jogo="Tekken Tag Tournament 2", Plataforma="Xbox 360", Ano="2012"},
                new Plataformas {ID=29, Jogo="Tekken Tag Tournament 2", Plataforma="Wii U", Ano="2012"},
            };
            plataformas.ForEach(cc => context.Plataformas.AddOrUpdate(c => c.ID, cc));
            context.SaveChanges();

            // adiciona JOGO

            var jogos = new List<Jogos> {
               new Jogos {ID=1, Titulo="Tekken",  Genero="Luta", Fotografia="Tekken.jpg",  ListaDePlataformas = new List<Plataformas>{ plataformas[0], plataformas[1] }, Ano = "1994" },
               new Jogos {ID=2, Titulo="Tekken 2",  Genero="Luta", Fotografia="Tekken2.jpg",  ListaDePlataformas = new List<Plataformas>{ plataformas[2], plataformas[3] }, Ano = "1995" },
               new Jogos {ID=3, Titulo="Tekken 3",  Genero="Luta", Fotografia="Tekken3.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[4], plataformas[5] }, Ano = "1997" },
               new Jogos {ID=4, Titulo="Tekken 4",  Genero="Luta", Fotografia="Tekken4.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[6], plataformas[7] }, Ano = "2001" },
               new Jogos {ID=5, Titulo="Tekken 5",  Genero="Luta", Fotografia="Tekken5.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[8], plataformas[9] }, Ano = "2004" },
               new Jogos {ID=6, Titulo="Tekken 5: Dark Resurrection",  Genero="Luta", Fotografia="Tekken5DarkResurrection.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[10], plataformas[11] }, Ano = "2005" },
               new Jogos {ID=7, Titulo="Tekken 6",  Genero="Luta", Fotografia="Tekken6.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[12], plataformas[13], plataformas[14] }, Ano = "2007" },
               new Jogos {ID=8, Titulo="Tekken 6: Bloodline Rebellion",  Genero="Luta", Fotografia="Tekken6BloodlineRebellion.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[15], plataformas[16], plataformas[17], plataformas[18] }, Ano="2008" },
               new Jogos {ID=9, Titulo="Tekken 7",  Genero="Luta", Fotografia="Tekken7.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[19], plataformas[20], plataformas[21], plataformas[22] }, Ano = "2015" },
               new Jogos {ID=10, Titulo="Tekken Tag Tournament",  Genero="Luta", Fotografia="TekkenTagTournament.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[23], plataformas[24] }, Ano = "1999" },
               new Jogos {ID=11, Titulo="Tekken Tournament 2",  Genero="Luta", Fotografia="TekkenTagTournament2.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[25], plataformas[26], plataformas[27], plataformas[28] }, Ano = "1999" },

};
            jogos.ForEach(vv => context.Jogos.AddOrUpdate(v => v.ID, vv));
            context.SaveChanges();

            // adiciona PERSONAGENS

            var personagens = new List<Personagens> {
                new Personagens {ID=1, Nome="Kazuya Mishima", Origem="Japão", Estreia="Tekken 1", TipoLuta="Caratê de Combate estilo Mishima", Fotografia="Kazuya.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] } },

                new Personagens {ID=2, Nome="Nina Williams", Origem="Irlanda", Estreia="Tekken 1", TipoLuta="Artes de Assassinato baseadas no Aikido e no Koppojutsu", Fotografia="Nina.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] } },

                new Personagens {ID=3, Nome="Marshall Law", Origem="USA", Estreia="Tekken 1", TipoLuta="Artes Marciais", Fotografia="MarshallLaw.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] } },

                new Personagens {ID=4, Nome="Yoshimitsu", Origem="Desconhecida", Estreia="Tekken 1", TipoLuta="Ninjutsu Manji Avançado", Fotografia="Yoshimitsu.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=5, Nome="Jack", Origem="Russia", Estreia="Tekken 1", TipoLuta="Força Bruta", Fotografia="Jack.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[2], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=6, Nome="King", Origem="Mexico", Estreia="Tekken 1", TipoLuta="Pro-Wrestling", Fotografia="King.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1] }},

                new Personagens {ID=7, Nome="Anna Williams", Origem="Irlanda", Estreia="Tekken 1", TipoLuta="Técnicas baseadas em Aikido, Koppojutsu e artes de Assassinato", Fotografia="Anna.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[2], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=8, Nome="Ganryu", Origem="Japão", Estreia="Tekken 1", TipoLuta="Sumo", Fotografia="Ganryu.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=9, Nome="Lee Chaolan", Origem="China", Estreia="Tekken 1", TipoLuta="Caraté de Combate estilo Mishima com Artes Marciais", Fotografia="Lee.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=10, Nome="Prototype Jack", Origem="Russia", Estreia="Tekken 1", TipoLuta="Força Bruta", Fotografia="PrototypeJack.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=11, Nome="Armor King", Origem="Desconhecida", Estreia="Tekken 1", TipoLuta="Pro-Wrestling", Fotografia="ArmorKing.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[9] }},

                new Personagens {ID=12, Nome="Kunimitsu", Origem="Japão", Estreia="Tekken 1", TipoLuta="Manji Ninjutsu", Fotografia="Kunimitsu.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=13, Nome="Kuma", Origem="Japão", Estreia="Tekken 1", TipoLuta="Kuma Shinken estilo Heihachi", Fotografia="Kuma.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1] }},

                new Personagens {ID=14, Nome="Heihachi Mishima", Origem="Japão", Estreia="Tekken 1", TipoLuta="Caraté de Combate estilo Mishima", Fotografia="Heihachi.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=15, Nome="Paul", Origem="USA", Estreia="Tekken 1", TipoLuta="Judo", Fotografia="Paul.jpg", ListaDeJogos = new List<Jogos>{ jogos [0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=16, Nome="Devil Kazuya", Origem="Desconhecida", Estreia="Tekken 1", TipoLuta="Caraté de Combate estilo Mishima", Fotografia="DevilKazuya.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[8],  jogos[9], jogos[10] }},

                new Personagens {ID=17, Nome="Michelle Chang", Origem="USA", Estreia="Tekken 1", TipoLuta="Xin Yi Liu He Quan e Baji Quan baseado em artes marciais chinesas", Fotografia="Michelle.jpg", ListaDeJogos = new List<Jogos>{ jogos[0], jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=18, Nome="Jun Kazama", Origem="Japão", Estreia="Tekken 2", TipoLuta="Artes marciais tradicionais estilo Kazama", Fotografia="Jun.jpg", ListaDeJogos = new List<Jogos>{ jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=19, Nome="Lei Wulong", Origem="Hong Kong", Estreia="Tekken 2", TipoLuta="Five Animals Form e Drunken Boxing baseado em artes marciais chinesas", Fotografia="Lei.jpg", ListaDeJogos = new List<Jogos>{ jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=20, Nome="Wang Jinrei", Origem="China", Estreia="Tekken 2", TipoLuta="Xin Yi Liu He Quan", Fotografia="Wang.jpg", ListaDeJogos = new List<Jogos>{ jogos [0], jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=21, Nome="Roger", Origem="Amostra de DNA retirada de um canguru", Estreia="Tekken 2", TipoLuta="Commando Wrestling", Fotografia="Roger.jpg", ListaDeJogos = new List<Jogos>{ jogos[1], jogos[9] }},

                new Personagens {ID=22, Nome="Alex", Origem="Amostra de DNA retirada de um inseto", Estreia="Tekken 2", TipoLuta="Commando Wrestling", Fotografia="Alex.jpg", ListaDeJogos = new List<Jogos>{ jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=23, Nome="Baek Doo San", Origem="Coreia do Sul", Estreia="Tekken 2", TipoLuta="Taekwondo", Fotografia="Baek.jpg", ListaDeJogos = new List<Jogos>{ jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=24, Nome="Bruce Irvin", Origem="USA", Estreia="Tekken 2", TipoLuta="Muay Thai", Fotografia="Bruce.jpg", ListaDeJogos = new List<Jogos>{ jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=25, Nome="Jin Kazama", Origem="Japão", Estreia="Tekken 3", TipoLuta="Caraté de luta avançada estilo Mishima com artes marciais tradicionais estilo Kazama", Fotografia="Jin.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=26, Nome="Mokujin", Origem="Japão", Estreia="Tekken 3", TipoLuta="Mimicry", Fotografia="Mokujin.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[4], jogos[5], jogos[6], jogos[9], jogos[10] }},

                new Personagens {ID=27, Nome="Forest Law", Origem="USA", Estreia="Tekken 3", TipoLuta="Artes marciais baseadas em Jeet Kune Do", Fotografia="ForestLaw.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=28, Nome="King II", Origem="Mexico", Estreia="Tekken 3", TipoLuta="Pro-Wrestling", Fotografia="KingII.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=29, Nome="Ling Xiaoyu", Origem="China", Estreia="Tekken 3", TipoLuta="Baguazhang e Piguaquan baseados em artes marciais chinesas", Fotografia="Xiaoyu.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=30, Nome="Julia Chang", Origem="USA", Estreia="Tekken 3", TipoLuta="Xin Yi Liu He Quan e Baji Quan baseados em artes marciais chinesas", Fotografia="Julia.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=31, Nome="Hwoarang", Origem="Coreia do Sul", Estreia="Tekken 3", TipoLuta="Taekwondo", Fotografia="Hwoarang.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=32, Nome="Eddy Gordo", Origem="Brasil", Estreia="Tekken 3", TipoLuta="Capoeira", Fotografia="Eddy.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=33, Nome="Bryan Fury", Origem="USA", Estreia="Tekken 3", TipoLuta="Kickboxing", Fotografia="Bryan.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=34, Nome="Kuma II", Origem="Irlanda", Estreia="Tekken 3", TipoLuta="Kuma Shinken estilo Heihachi", Fotografia="KumaII.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=35, Nome="Ogre", Origem="Desconhecida", Estreia="Tekken 3", TipoLuta="Toshin", Fotografia="Ogre.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=36, Nome="True Ogre", Origem="Desconhecida", Estreia="Tekken 3", TipoLuta="Desconhecida", Fotografia="TrueOgre.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=37, Nome="Panda", Origem="China", Estreia="Tekken 3", TipoLuta="Kuma Shinken estilo Heihachi", Fotografia="Panda.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=38, Nome="Tiger Jackson", Origem="Desconhecida", Estreia="Tekken 3", TipoLuta="Capoeira", Fotografia="TigerJackson.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=39, Nome="Doctor Bosconovitch", Origem="Russia", Estreia="Tekken 3", TipoLuta="Tudo o que ele sabe", Fotografia="DoctorBosconovitch.jpg", ListaDeJogos = new List<Jogos>{ jogos[2], jogos[10] }},

                new Personagens {ID=40, Nome="Gon", Origem="Desconhecida", Estreia="Tekken 3", TipoLuta="Desconhecida", Fotografia="Gon.jpg", ListaDeJogos = new List<Jogos>{ jogos[2] }},

                new Personagens {ID=41, Nome="Christie Monteiro", Origem="Brasil", Estreia="Tekken 4", TipoLuta="Capoeira", Fotografia="Christie.jpg", ListaDeJogos = new List<Jogos>{ jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=42, Nome="Craig Marduk", Origem="Australia", Estreia="Tekken 4", TipoLuta="Vale Tudo", Fotografia="Marduk.jpg", ListaDeJogos = new List<Jogos>{ jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=43, Nome="Steve Fox", Origem="Reino Unido", Estreia="Tekken 4", TipoLuta="Box", Fotografia="Steve.jpg", ListaDeJogos = new List<Jogos>{ jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=44, Nome="Combot", Origem="Frabicado pela Violet Systems", Estreia="Tekken 4", TipoLuta="Mimicry", Fotografia="Combot.jpg", ListaDeJogos = new List<Jogos>{ jogos[3], jogos[10] }},

                new Personagens {ID=45, Nome="Violet", Origem="Japão", Estreia="Tekken 4", TipoLuta="Artes marciais baseadas em Jeet Kune Do", Fotografia="Violet.jpg", ListaDeJogos = new List<Jogos>{ jogos[3], jogos[8], jogos[10] }},

                new Personagens {ID=46, Nome="Miharu Hirano", Origem="Japão", Estreia="Tekken 4", TipoLuta="Baguazhang e Piguaquan baseados em artes marciais chinesas", Fotografia="Miharu.jpg", ListaDeJogos = new List<Jogos>{ jogos[3], jogos[10] }},

                new Personagens {ID=47, Nome="Feng Wei", Origem="China", Estreia="Tekken 5", TipoLuta="Artes marciais do estilo God Fist", Fotografia="Feng.jpg", ListaDeJogos = new List<Jogos>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=48, Nome="Asuka Kazama", Origem="Japão", Estreia="Tekken 5", TipoLuta="Artes marciais tradicionais estilo Kazama", Fotografia="Asuka.jpg", ListaDeJogos = new List<Jogos>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=49, Nome="Raven", Origem="Desconhecida", Estreia="Tekken 5", TipoLuta="Ninjutsu", Fotografia="Raven.jpg", ListaDeJogos = new List<Jogos>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=50, Nome="Devil Jin", Origem="Desconhecida", Estreia="Tekken 5", TipoLuta="Caraté de luta avançada estilo Mishima com artes marciais tradicionais estilo Kazama", Fotografia="DevilJin.jpg", ListaDeJogos = new List<Jogos>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=51, Nome="Roger Jr.", Origem="Desconhecida", Estreia="Tekken 5", TipoLuta="Commando Wrestling", Fotografia="RogerJr.jpg", ListaDeJogos = new List<Jogos>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=52, Nome="Jinpachi Mishima", Origem="Japão", Estreia="Tekken 5", TipoLuta="Caraté de Combate estilo Mishima", Fotografia="Jinpachi.jpg", ListaDeJogos = new List<Jogos>{ jogos[5], jogos[10] }},

                new Personagens {ID=53, Nome="Armor King II", Origem="Irlanda", Estreia="Tekken 5: Dark Resurrection", TipoLuta="Pro-Wrestling", Fotografia="ArmorKingII.jpg", ListaDeJogos = new List<Jogos>{ jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=54, Nome="Lili De Rochefort", Origem="Monaco", Estreia="Tekken 5: Dark Resurrection", TipoLuta="Auto-ensinada", Fotografia="Lili.jpg", ListaDeJogos = new List<Jogos>{ jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=55, Nome="Sergei Dragrunov", Origem="Russia", Estreia="Tekken 5: Dark Resurrection", TipoLuta="Commando Sambo", Fotografia="Sergei.jpg", ListaDeJogos = new List<Jogos>{ jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=56, Nome="Alisa Bosconovitch", Origem="Russia", Estreia="Tekken 6: Bloodline Rebellion", TipoLuta="Combate de alta mobilidade usando propulsores", Fotografia="Alisa.jpg", ListaDeJogos = new List<Jogos>{ jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=57, Nome="Bob Richards", Origem="USA", Estreia="Tekken 6", TipoLuta="Karaté Freestyle", Fotografia="Bob.jpg", ListaDeJogos = new List<Jogos>{ jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=58, Nome="Lars Alexandersson", Origem="Suécia", Estreia="Tekken 6: Bloodline Rebellion", TipoLuta="Karaté e Artes Marciais Tekken Forces", Fotografia="Lars.jpg", ListaDeJogos = new List<Jogos>{ jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=59, Nome="Leo Kliesen", Origem="Alemanha", Estreia="Tekken 6", TipoLuta="Baji Quan", Fotografia="Leo.jpg", ListaDeJogos = new List<Jogos>{ jogos[6], jogos[7], jogos[8], jogos[10] } },

                new Personagens {ID=60, Nome="Miguel Rojo", Origem="Spain", Estreia="Tekken 6", TipoLuta="Não definido (Luta de rua)", Fotografia="Miguel.jpg", ListaDeJogos = new List<Jogos>{ jogos[6], jogos[7], jogos[8], jogos[10] } },

                new Personagens {ID=61, Nome="Zafina", Origem="Egipto", Estreia="Tekken 6", TipoLuta="Artes antigas de Assassinato", Fotografia="Zafina.jpg", ListaDeJogos = new List<Jogos>{ jogos[6], jogos[7], jogos[8], jogos[10] } },

                new Personagens {ID=62, Nome="Akuma", Origem="Japão", Estreia="Tekken 7", TipoLuta="Artes Marciais", Fotografia="Akuma.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=63, Nome="Claudio Serafino", Origem="Itália", Estreia="Tekken 7", TipoLuta="Feitiçaria de Exorcismo estilo Sirius", Fotografia="Claudio.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=64, Nome="Geese Howard", Origem="USA", Estreia="Tekken 7", TipoLuta="Kobujutsu", Fotografia="Geese.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=65, Nome="Gigas", Origem="Desconhecida", Estreia="Tekken 7", TipoLuta="Impulso Destrutivo", Fotografia="Gigas.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=66, Nome="Josie Rizal", Origem="Filipinas", Estreia="Tekken 7", TipoLuta="Kickboxing baseado em Eskrima", Fotografia="Josie.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=67, Nome="Katarina Alves", Origem="Brasil", Estreia="Tekken 7", TipoLuta="Savate", Fotografia="Katarina.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=68, Nome="Kazumi Mishima", Origem="Arábia Saudita", Estreia="Tekken 7", TipoLuta="Karaté estilo Hachijo misturado com Karaté de Combato estilo Mishima", Fotografia="Kazumi.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=69, Nome="Shaheen", Origem="Irlanda", Estreia="Tekken 2", TipoLuta="Estilo militar de combate", Fotografia="Shaheen.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=70, Nome="Master Raven", Origem="Desconhecida", Estreia="Tekken 7", TipoLuta="Ninjutsu", Fotografia="MasterRaven.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=71, Nome="Noctis Lucis Caelum", Origem="Irlanda", Estreia="Tekken 7", TipoLuta="Weapon Summoning", Fotografia="Noctis.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=72, Nome="Lucky Chloe", Origem="Desconhecida", Estreia="Tekken 7", TipoLuta="Dança Freestyle e acrobática", Fotografia="LuckyChloe.jpg", ListaDeJogos = new List<Jogos>{ jogos[8] } },

                new Personagens {ID=73, Nome="Tetsujin", Origem="Desconhecida", Estreia="Tekken Tag Tournament", TipoLuta="Mimicry", Fotografia="Tetsujin.jpg", ListaDeJogos = new List<Jogos>{ jogos[9] } },

                new Personagens {ID=74, Nome="Unknown", Origem="Desconhecida", Estreia="Tekken Tag Tournament", TipoLuta="Mimicry",  Fotografia="Unknown.jpg", ListaDeJogos = new List<Jogos>{ jogos[9], jogos[10] } },

                new Personagens {ID=75, Nome="Jaycee", Origem="USA", Estreia="Tekken Tag Tournament 2", TipoLuta="Pro-Wrestling, Xin Yi Liu He Quan e Baji Quan baseados em artes marciais chinesas", Fotografia="Jaycee.jpg", ListaDeJogos = new List<Jogos> { jogos[10] } },

                new Personagens {ID=76, Nome="Sebastian", Origem="Monaco", Estreia="Tekken Tag Tournament 2", TipoLuta="Dança Freestyle e acrobática", Fotografia="Sebastian.jpg", ListaDeJogos = new List<Jogos>{ jogos[10] } },

                new Personagens {ID=77, Nome="Slim Bob", Origem="USA", Estreia="Tekken Tag Tournament 2", TipoLuta="Karaté estilo livre", Fotografia="SlimBob.jpg", ListaDeJogos = new List<Jogos>{ jogos[10] } },

};
            personagens.ForEach(aa => context.Personagens.AddOrUpdate(a => a.Nome, aa));
            context.SaveChanges();



            // adiciona HISTORIA

            var historia = new List<Historia> {
           new Historia {ID=1, Nome="Tekken 1", Resumo="Um torneio mundial de artes marciais está a chegar ao fim, com uma grande quantia de prêmios em dinheiro concedida ao lutador que derrotar Heihachi Mishima na ronda final da competição. O concurso é patrocinado por uma grande empresa chamada o Mishima Zaibatsu. Há oito lutadores que permanecem após vencerem as partidas de morte em todo o mundo, com o vencedor do torneio recebendo o título de Rei do Punho de Ferro. Apenas um terá a chance de derrotar Heihachi e levar para casa o prêmio em dinheiro e a fama. Kazuya Mishima é a personagem principal. Filho biológico de Heihachi, ele foi jogado em uma ravina pelo seu pai quando tinha cinco anos de idade. Heihachi, acreditando que seu filho era fraco demais para herdar seu conglomerado, decidiu que, se fosse realmente forte o suficiente, seria capaz de sobreviver à queda e subir de volta. Kazuya sobreviveu. Alimentado pelo ódio por seu pai, ele entra no torneio para se vingar. Descubra como termina esta reviravolta!",JogoFK=1},

           new Historia {ID=2, Nome="Tekken 2", Resumo="Kazuya Mishima venceu o torneio King of Iron Fist, atirando o seu pai pela ravina, e está na liderança da Mishima Zaibatsu. O torneio regressa com a sua segunda edição, agora com o prémio mil vezes maior. Quem conseguirá a liderança da Mishima Zaibatsu, Heihachi ou Kazuya?!", JogoFK=2},

           new Historia {ID=3, Nome="Tekken 3", Resumo="Após dezesseis anos do segundo Torneio King of Iron Fist, com a vitória de Heihachi, este estabeleceu a Tekken Force, uma organização dedicada à proteção do Mishima Zaibatsu. Um perigo ameaçou os soldados da Tekken Force, chamada de Ogre. Heihachi então decide procura-lo com o objetivo de dominar o mundo, com a ajuda do seu neto, Jin Kazama, que pretende vingança pelo desaparecimento da sua mãe. Descobre como terminará este enredo!", JogoFK=3},

           new Historia {ID=4, Nome="Tekken 4", Resumo="Jin, depois de conseguir derrotar o Ogre, lutou com o seu avô e derrotou-o pelo facto do mesmo o ter usado. Contudo, Heihachi continua na liderança da Mishima Zaibatsu e esta anunciou o Torneio King of Iron Fist 4 e colocou o enorme império financeiro como o principal prêmio. O campeão que conseguir derrotar Heihachi no final do Torneio herdará a Mishima Zaibatsu.",JogoFK=4},

           new Historia {ID=5, Nome="Tekken 5", Resumo=" Uma nova personagem lidera Mishima Zaibatsu: Jinpachi Mishima. Pai de Heihachi Mishima, e, consequentemente, avô e bisavô de Kazuya e Jin Kazama. Jinpachi teria sido enterrado vivo pelo próprio filho para o mesmo liderar a sua empresa. Descobre quem o derrotará e terá a liderança da maior empresa do mundo! ",JogoFK=5},

           new Historia {ID=6, Nome="Tekken 5: Dark Resurrection", Resumo="O jogo segue exatamente o mesmo enredo de Tekken 5, apenas com as adições de dois novos personagens e um personagem que retorna; Emilie 'Lili' De Rochefort (que procura destruir o Mishima Zaibatsu e acabar com o problema financeiro de seu pai), Sergei Dragunov (um membro de Spetsnaz que foi enviado para capturar Jin) e Armor King II (que foi pensado para ter sido morto antes os eventos de Tekken 4 e cuja identidade e objetivos permanecem um mistério para o jogador).",JogoFK=6},

           new Historia {ID=7, Nome="Tekken 6", Resumo="Jin Kazama, que derrotou os seus parentes mais velhos, tomou a posse da Mishima Zaibatsu. Agora, Jin parece possuir ambições tirânicas. Usando seus recursos dentro da organização para se tornar uma superpotência global, ele separa os laços nacionais do Mishima Zaibatsu e abertamente declara guerra contra todas as nações no ano seguinte. Essa ação mergulha o mundo em uma espiral extremamente caótica, com uma guerra civil em grande escala em erupção ao redor do globo e até mesmo em meio às colônias espaciais que orbitam o planeta. Seu pai biológico, Kazuya Mishima, lidera a empresa rival de Zaibatsu, a G Corporation. Jogue para descobrir como irá acabar esta intensa guerra!.",JogoFK=7},

           new Historia {ID=8, Nome="Tekken 6: Bloodline Rebellion", Resumo="Tem o mesmo enredo do Tekken 6.",JogoFK=8},

           new Historia {ID=9, Nome="Tekken 7", Resumo="Após os eventos de Tekken 6, a guerra entre a Mishima Zaibatsu e a G Corporation ainda continua junto com o desaparecimento de Jin Kazama. Com Heihachi na liderança da Mishima Zaibatsu após derrotar Nina (guarda de Jin que tem um papel importante na Mishima Zaibatsu), anuncia o torneio Torneio King of Iron Fist 7. As duas empresas procuram Jin e tentam expôr os podres uma da outra de forma a que cada uma vá à falência. Depois de muita confusão, Heihachi e Kazuya voltam a enfrentar-se para uma batalha final que termina na morte de um deles.",JogoFK=9},
           new Historia {ID=10, Nome="Tekken Tag Tournament", Resumo="Não pertence à história canónica do jogo.",JogoFK=10},
           new Historia {ID=11, Nome="Tekken Tag Tournament 2", Resumo="Não pertence à história canónica do jogo.",JogoFK=11},
};
            historia.ForEach(bb => context.Historia.AddOrUpdate(b => b.ID, bb));
            context.SaveChanges();

            // add COMENTÁRIOS

            var comentarios = new List<Comentarios>
            {
                new Comentarios {ID = 1, Texto = "O meu jogo preferido é o Tekken 4!!", DataComentario = new DateTime(2018,6,26), JogoFK = 4, UtilizadoresFK = 1},
                new Comentarios {ID = 2, Texto = "Este site é muito bom.", DataComentario = new DateTime(2018,6,28),JogoFK=4,UtilizadoresFK=1},
                new Comentarios {ID = 3, Texto = "Vou partilhar este site com os meus amigos :)", DataComentario = new DateTime(2018,7,5),JogoFK=4,UtilizadoresFK=1},
                new Comentarios {ID = 4, Texto = "porque é que esta personagem faz aqui?", DataComentario = new DateTime(2018,7,5),JogoFK=4,UtilizadoresFK=1},
            };
            comentarios.ForEach(bb => context.Comentarios.AddOrUpdate(b => b.ID, bb));
            context.SaveChanges();
        }
    }
}