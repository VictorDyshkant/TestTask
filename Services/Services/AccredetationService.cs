using Abstraction.Entities;
using Abstraction.Exceptions;
using Abstraction.Models;
using Abstraction.Services;
using Abstraction.UnitOfWork;
using AutoMapper;

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

        public async Task AssigneAccredetation(int personId, AccredetationModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory())
            {
                var person = await unitOfWork.PersonRepository.GetByIdAsync(personId);
                if (person == null)
                {
                    throw new NotFoundException($"Person with id = {personId} was not found.");
                }

                if (person.Accreditation != null)
                {
                    throw new InvalidOperationException("Accreditation already assigend.");
                }

                person.Accreditation = _mapper.Map<Accreditation>(model);

                await unitOfWork.CommitAsync();
            }
        }

        public async Task UnAssigneAccredetation(int personId)
        {
            using (var unitOfWork = _unitOfWorkFactory())
            {
                var person = await unitOfWork.PersonRepository.GetByIdAsync(personId);
                if (person == null)
                {
                    throw new Exception($"Person with id = {personId} was not found.");
                }

                if (person.Accreditation != null)
                {
                    throw new InvalidOperationException("Accreditation is not assigend on current person.");
                }

                unitOfWork.AccredetationRepository.Delete(person.Accreditation.Id);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task UpdateAccredetation(int personId, AccredetationModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory())
            {
                var person = await unitOfWork.PersonRepository.GetByIdAsync(personId);
                if (person == null)
                {
                    throw new NotFoundException($"Person with id = {personId} was not found.");
                }

                if (person.Accreditation != null)
                {
                    throw new InvalidOperationException("Accreditation already assigend.");
                }

                person.Accreditation.Status = model.Status;
                person.Accreditation.Expires = model.Expires;

                unitOfWork.AccredetationRepository.Update(person.Accreditation);
                await unitOfWork.CommitAsync();
            }
        }
    }
}
