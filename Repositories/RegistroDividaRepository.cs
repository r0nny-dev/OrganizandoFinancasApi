using Microsoft.EntityFrameworkCore;
using OrganizingFinances.Context;
using OrganizingFinances.DTOs;
using OrganizingFinances.Entities;
using OrganizingFinances.Repositories.Interfaces;

namespace OrganizingFinances.Repositories;

public class RegistroDividaRepository : IRegistroDividaRepository
{
    private readonly DatabaseContext _context;
    private readonly DbSet<RegistroDivida> _dbSet;

    public RegistroDividaRepository(DatabaseContext context)
    {
        _context = context;
        _dbSet = _context.Set<RegistroDivida>();
    }

    public IEnumerable<RegistroDividaDTO> GetAll()
    {
        var RegistroDividas = _dbSet.Select(x =>
            new RegistroDividaDTO(x.IdRegistro, x.TituloRegistro, x.ValorRegistro, x.DataDeVencimento, x.Observacoes)

        ).ToList();

        return RegistroDividas;
    }

    public RegistroDividaDTO GetById(Guid IdRegistro)
    {
        var registroDivida = _dbSet.FirstOrDefault(x => x.IdRegistro == IdRegistro);

        if (registroDivida == null)
            return null;

        return new RegistroDividaDTO(registroDivida.IdRegistro, registroDivida.TituloRegistro, registroDivida.ValorRegistro,
                                    registroDivida.DataDeVencimento, registroDivida.Observacoes);
    }

    public void Insert(RegistroDividaDTO registroDividaDTO)
    {
        //registroDividaDTO.IdRegistro = new Guid();
        //_dbSet.Add(registroDividaDTO.ToRegistroDivida());
        //Save();
        var registro = new RegistroDivida(registroDividaDTO);

        _dbSet.Add(registro);
        Save();
    }

    public void Update(RegistroDividaDTO registroDividaDTO)
    {
        var registroDivida = new RegistroDivida(registroDividaDTO);

        _dbSet.Update(registroDivida);
        Save();
    }

    public void Delete(Guid IdRegistro)
    {
        var RegistroDivida = _dbSet.FirstOrDefault(x => x.IdRegistro == IdRegistro);
        _dbSet.Remove(RegistroDivida);
        Save();
    }

    public void Save()
    {
        _context.SaveChangesAsync();
    }
}
