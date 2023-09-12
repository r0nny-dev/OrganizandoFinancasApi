using OrganizingFinances.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrganizingFinances.DTOs;

public class RegistroDividaDTO
{
    public Guid IdRegistro { get; set; }

    [Display(Name = "Título Registro")]
    [Required(ErrorMessage = "O Título Registro é Obrigatório.")]
    [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "O Título Registro deve conter entre 3 e 100 letras.")]
    public string TituloRegistro { get; set; } = string.Empty;

    [Display(Name = "Valor Registro")]
    [Required(ErrorMessage = "O Valor Registro é Obrigatório.")]
    public double ValorRegistro { get; set; }

    [Display(Name = "Data de Vencimento")]
    [Required(ErrorMessage = "A Data de Vencimento é Obrigatória.")]
    public DateOnly DataDeVencimento { get; set; }

    [Display(Name = "Observações")]
    [StringLength(maximumLength: 500, ErrorMessage = "O campo de Observações deve conter no máximo 500 letras.")]
    public string? Observacoes { get; set; } = string.Empty;

    public RegistroDividaDTO(RegistroDivida registroDivida)
    {
        IdRegistro = registroDivida.IdRegistro;
        TituloRegistro = registroDivida.TituloRegistro;
        ValorRegistro = registroDivida.ValorRegistro;
        DataDeVencimento = registroDivida.DataDeVencimento;
        Observacoes = registroDivida.Observacoes;
    }

    public RegistroDividaDTO(Guid idRegistro, string tituloRegistro, double valorRegistro, DateOnly dataDeVencimento, string? observacoes)
    {
        IdRegistro = idRegistro;
        TituloRegistro = tituloRegistro;
        ValorRegistro = valorRegistro;
        DataDeVencimento = dataDeVencimento;
        Observacoes = observacoes;
    }
}
