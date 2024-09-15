using System.ComponentModel.DataAnnotations;

public class Produto
{
    [Required(ErrorMessage = "A descrição é obrigatória.")]
    public string Descricao { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Preco { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo.")]
    public int Estoque { get; set; }

    [Required(ErrorMessage = "O código do produto é obrigatório.")]
    [CustomValidation(typeof(Produto), nameof(ValidarCodigoProduto))]
    public string CodigoProduto { get; set; }

    public static ValidationResult ValidarCodigoProduto(string codigoProduto, ValidationContext context)
    {
        if (string.IsNullOrWhiteSpace(codigoProduto))
        {
            return new ValidationResult("O código do produto é obrigatório.");
        }

        // Verifica o formato AAA-1234
        var regex = new System.Text.RegularExpressions.Regex(@"^[A-Z]{3}-\d{4}$");
        if (!regex.IsMatch(codigoProduto))
        {
            return new ValidationResult("O código do produto deve estar no formato 'AAA-1234'.");
        }

        return ValidationResult.Success;
    }
}
