using Abstraction.Exceptions;
using Abstraction.Models;
using Abstraction.Services;
using Abstraction.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AccredetationService : IAccredetationService
    {
        private Func<IUnitOfWork> _unitOfWorkFactory { get; }
        private readonly IMapper _mapper;

        public AccredetationService(Func<IUnitOfWork> unitOfWorkFactory, IMapper mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
        }
        public async Task<AccredetationGetModel> AssigneAccredetation(int personId, AccredetationModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory())
            {
                var person = await unitOfWork.PersonRepository.GetByIdAsync(personId);
                var acc = person.Accreditation;
                if (person == null)
                {
                    throw new NotFoundException($"Person with id = {personId} was not found.");
                }
                acc.Status = model.Status;
                acc.Expires = model.Expires;

                await unitOfWork.CommitAsync();

                return _mapper.Map<AccredetationGetModel>(person);
            }
        }

        public async Task UnAssigneAccredetation(int personId, AccredetationModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory())
            {
                var person = await unitOfWork.PersonRepository.GetByIdAsync(personId);
                var acc = person.Accreditation;
                if (person == null)
                {
                    throw new Exception($"Person with id = {personId} was not found.");
                }

                unitOfWork.PersonRepository.Delete(personId);
                await unitOfWork.CommitAsync();
            }
        }
    }
}
