using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.MedarbejderKomp;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Queries;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.MedarbejderKomp
{
    public class GetAllByMedarbejderIdQueryKompetence : IGetAllByMedarbejderIdQueryKompetence
    {
        private readonly IRepositoryMedarbejderKomp _repository;

        public GetAllByMedarbejderIdQueryKompetence(IRepositoryMedarbejderKomp repository)
        {
            _repository = repository;
        }


        IEnumerable<QueryResultDtoMedarbejderKomp> IGetAllByMedarbejderIdQueryKompetence.GetAllByMedarbejderId(int id)
        {
            return _repository.GetAllKompetencerByMedarbejderId(id);
        }
    }
}
