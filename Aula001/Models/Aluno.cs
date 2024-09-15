using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class Aluno
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O RA é obrigatório.")]
    [RegularExpression(@"^RA\d{6}$", ErrorMessage = "O RA deve começar com 'RA' seguido de 6 dígitos.")]
    public string Ra { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido.")]
    public string Cpf { get; set; }

    public bool Ativo { get; set; }
}
