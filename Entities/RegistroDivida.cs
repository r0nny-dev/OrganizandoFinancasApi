using OrganizingFinances.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizingFinances.Entities;

public class RegistroDivida
{
    [Key]
    public Guid IdRegistro { get; set; }
    public string TituloRegistro { get; set; } = string.Empty;
    public double ValorRegistro { get; set; }
    public DateOnly DataDeVencimento { get; set; }
    public string? Observacoes { get; set; } = string.Empty;

    public RegistroDivida(Guid idRegistro, string tituloRegistro, double valorRegistro, DateOnly dataDeVencimento, string? observacoes)
    {
        IdRegistro = idRegistro;
        TituloRegistro = tituloRegistro;
        ValorRegistro = valorRegistro;
        DataDeVencimento = dataDeVencimento;
        Observacoes = observacoes;
    }

    public RegistroDivida(RegistroDividaDTO registroDTO)
    {
        IdRegistro = registroDTO.IdRegistro;
        TituloRegistro = registroDTO.TituloRegistro;
        ValorRegistro = registroDTO.ValorRegistro;
        DataDeVencimento = registroDTO.DataDeVencimento;
        Observacoes = registroDTO.Observacoes;
    }
}
