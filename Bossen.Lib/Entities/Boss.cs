using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bossen.Lib.Entities
{
    public class Boss
    {
        public List<Boom> Bomen { get; set; }

        public string Naam { get; set; }

        public Boss(string naam)
        {
            Naam = naam;
            LaadMockData();
        }

        public bool SlapOp(Boom opTeSlaan)
        {
            bool opgeslagen = true;
            int index = GeefIndexBoom(opTeSlaan.Id);
            if (index == -1)
            {
                Bomen.Add(opTeSlaan);
            }
            else
            {
                Bomen[index] = opTeSlaan;
            }
            return opgeslagen;
        }

        public bool TeVerwijderen(Boom teVerwijderen)
        {
            bool verwijderd = true;
            Bomen.Remove(teVerwijderen);
            return verwijderd;
        }



        public int GeefIndexBoom(Guid id)
        {
            int index = -1;
            for (int i = 0; i < Bomen.Count; i++)
            {
                if (Bomen[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }


        public void LaadMockData()
        {

            Boom boom1 = new Boom
            {
                HoogteInMeter = 10.75F,
                Id = Guid.NewGuid()
                ,
                Naam = "Eik",
                Soort = Boomsoorten.loofboom
            };
            Boom boom2 = new Boom
            {
                HoogteInMeter = 10,
                Id = Guid.NewGuid(),
                Naam = "Spar",
                Soort = Boomsoorten.naaldboom
            };

            Boom boom3 = new Boom("Plataan", 12.3555555F);
            Boom boom4 = new Boom("Den", 8.75F, Boomsoorten.naaldboom);

            Bomen = new List<Boom> { boom1, boom2, boom3, boom4 };


        }

        public int GeefAantalBomen(Boomsoorten soort)
        {
            int aantal = 0;
            foreach (Boom boom in Bomen)
            {
                if (soort == boom.Soort)
                {
                    aantal++;
                }
            }

            return aantal;
        }
        public override string ToString()
        {
            return $"{Naam} : {Bomen.Count} bomen  ";
        }
    }


}
