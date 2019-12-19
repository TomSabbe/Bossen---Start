using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bossen.Lib.Entities
{
    public enum Boomsoorten { naaldboom, loofboom }

    public class Boom
    {
        public Guid Id { get; set; }

        public string Naam { get; set; }

        //public float HoogteInMeter { get; set; }

        private float hoogteInMeter;

        public float HoogteInMeter
        {
            get { return hoogteInMeter; }
            set
            {
                if (value >= 0.5 && value < 100)
                {
                    hoogteInMeter = value;
                }
                else
                {
                    throw new Exception(" De hoogte moet tussen de 0.5 en de 100 zijn");
                }


                
                
            }
        }


        public Boomsoorten Soort { get; set; }

        public Boom()
        {

        }

        public Boom(string boomNaam, float hoogteInMeter,
            Boomsoorten boomSoort = Boomsoorten.loofboom, Guid? id = null)
        {
            Naam = boomNaam;
            HoogteInMeter = hoogteInMeter;
            Soort = boomSoort;
            Id = id == null ? Guid.NewGuid() : (Guid)id;
            /*
             * Verlengde versie
            if (id == null)
            {
                id = Guid.NewGuid();
            }
            else
            {
                id = (Guid)id;
            }
            */
        }

        public override string ToString()
        {
            return $"{Naam}  {(HoogteInMeter * 100).ToString("0")} cm ";
        }


    }
}
