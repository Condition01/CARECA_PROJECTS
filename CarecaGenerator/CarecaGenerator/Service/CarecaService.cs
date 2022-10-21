using CarecaGenerator.Models;
using CarecaGenerator.Repository;

namespace CarecaGenerator.Service
{
    public class CarecaService: ICarecaService
    {
        private readonly ICarecaRepository _carecaRepository;

        public CarecaService(ICarecaRepository carecaRepository)
        {
            _carecaRepository = carecaRepository;
        }

        public Careca GetCareca()
        {
            return _carecaRepository.GetCareca();
        }
    }
}
