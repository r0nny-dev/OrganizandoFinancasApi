using OrganizingFinances.DTOs;

namespace OrganizingFinances.Repositories.Interfaces;

public interface IRegistroDividaRepository
{
    IEnumerable<RegistroDividaDTO> GetAll();
    RegistroDividaDTO GetById(Guid IdRegistro);
    void Insert(RegistroDividaDTO registroDividaDTO);
    void Update(RegistroDividaDTO registroDividaDTO);
    void Delete(Guid IdRegistro);
    void Save();
}
