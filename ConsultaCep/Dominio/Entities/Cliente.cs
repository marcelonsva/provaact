using ConsultaCep.Domain.Entities;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaCep.Domain.Entities
{
    public class Cliente
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [RegularExpression(@"\d{8}")]
        public string CEP { get; set; }
    }
}

public class ClienteValidator : AbstractValidator<Cliente>
{
    public ClienteValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(255).WithMessage("O nome deve ter no máximo 255 caracteres.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email não é válido.")
            .MaximumLength(255).WithMessage("O email deve ter no máximo 255 caracteres.");

        RuleFor(c => c.DataNascimento)
            .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
            .Must(BeAValidDate).WithMessage("A data de nascimento não é válida.");

        RuleFor(c => c.CEP)
            .NotEmpty().WithMessage("O CEP é obrigatório.")
            .MaximumLength(8).WithMessage("O CEP deve ter 8 caracteres.");
    }

    private bool BeAValidDate(DateTime date)
    {
        return date < DateTime.Now;
    }
}

