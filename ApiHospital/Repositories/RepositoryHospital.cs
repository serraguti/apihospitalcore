using ApiHospital.Data;
using ApiHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHospital.Repositories
{
    public class RepositoryHospital
    {
        HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<Hospital> GetHospitales()
        {
            return this.context.Hospitales.ToList();
        }

        public Hospital BuscarHospital(int idhospital)
        {
            return this.context.Hospitales
                .SingleOrDefault(x => x.IdHospital == idhospital);
        }
    }
}
