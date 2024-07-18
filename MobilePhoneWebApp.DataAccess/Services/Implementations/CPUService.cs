using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Exceptions;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.BusinessLogic.Services.Implementations
{
    public class CPUService : ICPUService
    {
        private readonly ICPURepository _cpuRepository;
        private readonly IMapper _mapper;
        public CPUService(ICPURepository cpuRepository, IMapper mapper)
        {
            _cpuRepository = cpuRepository;
            _mapper = mapper;
        }
        public async Task<CPUDto> AddAsync(CPUDto cpuDto)
        {
            var cpuReturned = await _cpuRepository.AddAsync(_mapper.Map<DataAccess.Entity.CPU>(cpuDto));

            return _mapper.Map<CPUDto>(cpuReturned);
        }

        public async Task<CPUDto> DeleteAsync(int id)
        {
            var cpuLooked = await _cpuRepository.GetByIdAsync(id);

            if (cpuLooked is null)
            {
                throw new NotFoundException("this cpu does not exist");
            }
            var cpuDeleted = await _cpuRepository.DeleteAsync(_mapper.Map<DataAccess.Entity.CPU>(cpuLooked));

            return _mapper.Map<CPUDto>(cpuDeleted);
        }

        public async Task<List<CPUDto>> GetAllAsync()
        {
            var cpus = await _cpuRepository.GetAllAsync();
            if (cpus is null)
            {
                throw new NotFoundException("there is no cpu");
            }

            return _mapper.Map<List<CPUDto>>(cpus);
        }

        public async Task<CPUDto> GetByIdAsync(int id)
        {
            var cpuLooked = await _cpuRepository.GetByIdAsync(id);
            if (cpuLooked is null)
            {
                throw new NotFoundException("this cpu does not exist");
            }

            return _mapper.Map<CPUDto>(cpuLooked);
        }

        public async Task<CPUDto> UpdateAsync(CPUDto cpuDto)
        {
            var cpuLooked = await _cpuRepository.GetByIdAsync(cpuDto.Id);
            if (cpuLooked is null)
            {
                throw new NotFoundException("this cpu does not exist");
            }

            _mapper.Map(cpuDto, cpuLooked);
            await _cpuRepository.UpdateAsync(cpuLooked);

            return cpuDto;
        }
    }
}
