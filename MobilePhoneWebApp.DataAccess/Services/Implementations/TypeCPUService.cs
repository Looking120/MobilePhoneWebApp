using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Exceptions;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Implementations;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Services.Implementations
{
    public class TypeCPUService : ITypeCPUService
    {
        private readonly ITypeCPURepository _typeCPURepository;
        private readonly IMapper _mapper;
        public TypeCPUService(ITypeCPURepository typeCPURepository, IMapper mapper)
        {
            _typeCPURepository = typeCPURepository;
            _mapper = mapper;
        }
        public async Task<TypeCPUDto> AddAsync(TypeCPUDto typeCPUDto)
        {
            var typeCPURetuned = await _typeCPURepository.AddAsync(_mapper.Map<TypeCPU>(typeCPUDto));

            return _mapper.Map<TypeCPUDto>(typeCPURetuned);
        }

        public async Task<TypeCPUDto> DeleteAsync(int id)
        {
            var typeCPULooked =await _typeCPURepository.GetByIdAsync(id);
            if (typeCPULooked is null)
            {
                throw new NotFoundException("this TypeCPU does not exist");
            }
            var typeCPUDeleted = await _typeCPURepository.DeleteAsync(_mapper.Map<TypeCPU>(typeCPULooked));

            return _mapper.Map<TypeCPUDto>(typeCPUDeleted);
        }

        public async Task<List<TypeCPUDto>> GetAllAsync()
        {
            var typeCPUs = await _typeCPURepository.GetAllAsync();
            if (typeCPUs is  null)
            {
                throw new NotFoundException("there us no TypeCPU");
            }

            return _mapper.Map<List<TypeCPUDto>>(typeCPUs);
        }

        public async Task<TypeCPUDto> GetByIdAsync(int id)
        {
            var typeCPULooked = await _typeCPURepository.GetByIdAsync(id);
            if (typeCPULooked is null)
            {
                throw new NotFoundException("this TypeCPU does not exist");
            }

            return _mapper.Map<TypeCPUDto>(typeCPULooked);
        }

        public async Task<TypeCPUDto> UpdateAsync(TypeCPUDto typeCPUDto)
        {
            var typeCPULooked = await _typeCPURepository.GetByIdAsync(typeCPUDto.Id);
            if (typeCPULooked is null)
            {
                throw new NotFoundException("the typeCPU is not exist");
            }
            _mapper.Map(typeCPUDto, typeCPULooked);
            await _typeCPURepository.UpdateAsync(typeCPULooked);

            return typeCPUDto;
        }
    }
}
