using BeautySalon.Contracts.Dtos;
using BeautySalon.Infrastructure;
using Mapster;

namespace BeautySalon.API.Mapping;

public class EmployeeMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Employees, EmployeeDTO>()
            .Map(dest => dest.Position, src => src.PositionNavigation.Name);
    }
}
