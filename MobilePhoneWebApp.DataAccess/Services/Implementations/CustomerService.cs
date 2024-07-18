using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Exceptions;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.BusinessLogic.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        } 
        public async Task<Dtos.CustomerDto> AddAsync(CustomerDto customerDto)
        {
            var customerReturned = await _customerRepository.AddAsync(_mapper.Map<Customer>(customerDto));

            return _mapper.Map<Dtos.CustomerDto>(customerReturned);  
        }

       public async Task<CustomerDto>DeleteAsync(int id)
       {
            var customerLooked = await _customerRepository.GetByIdAsync(id);

            if(customerLooked is null)
            {
                throw new NotFoundException("This customer does not exist");
            }

            var customerDeleted = await _customerRepository.DeleteAsync(_mapper.Map<Customer>(customerLooked));

            return _mapper.Map<Dtos.CustomerDto>(customerDeleted);
       }

        public async Task<List<Dtos.CustomerDto>>GetAllAsync()
        {
           var customers = await _customerRepository.GetAllAsync();

            if(customers is  null) 
            {
                throw new NotFoundException("There is no customers");
            }
            
            return _mapper.Map<List<Dtos.CustomerDto>>(customers);
        }

        public async Task<CustomerDto>GetByIdAsync(int id)
        {
            var customerLooked = await _customerRepository.GetByIdAsync(id);

            if (customerLooked is null)
            {
                throw new NotFoundException("This customer does not exist");
            }

            return _mapper.Map<CustomerDto>(customerLooked);
        }

        public async Task<CustomerDto>UpdateAsync(CustomerDto customerDto)
        {
            var customerLooked = await _customerRepository.GetByIdAsync(customerDto.Id);

            if (customerLooked is null)
            {
                throw new NotFoundException("This customer does not exist");
            }

            _mapper.Map(customerDto, customerLooked);
            await _customerRepository.UpdateAsync(customerLooked);

            return customerDto;
        }
    }
}
