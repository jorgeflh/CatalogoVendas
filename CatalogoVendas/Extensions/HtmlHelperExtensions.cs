using System.Text;
using System.Text.RegularExpressions;

namespace CatalogoVendas.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string DisplayCPF(string cpf)
        {
            Regex re = new Regex(@"([\d]{3})([\d]{3})([\d]{3})([\d]{2})");
            MatchCollection matches = re.Matches(cpf);

            StringBuilder cpfMasket = new StringBuilder();
            foreach (Match match in matches)
            {
                cpfMasket.Append(match.Groups[1].Value + ".");
                cpfMasket.Append(match.Groups[2].Value + ".");
                cpfMasket.Append(match.Groups[3].Value + "-" + match.Groups[4].Value);
                break;
            }

            return cpfMasket.ToString();
        }

        public static string DisplayTelefone(string telefone)
        {
            Regex re = new Regex(@"^([\d]{2})([\d]{4,5})([\d]+)$");
            MatchCollection matches = re.Matches(telefone);

            StringBuilder valueMaked = new StringBuilder();
            foreach (Match match in matches)
            {
                valueMaked.Append("(" + match.Groups[1].Value + ") ");
                valueMaked.Append(match.Groups[2].Value + "-" + match.Groups[3].Value);
                break;
            }

            return valueMaked.ToString();
        }

        public static string DisplayCNPJ(string cnpj)
        {
            Regex re = new Regex(@"([\d]{2})([\d]{3})([\d]{3})([\d]{4})([\d]{2})");
            MatchCollection matches = re.Matches(cnpj);

            StringBuilder valueMaked = new StringBuilder();
            foreach (Match match in matches)
            {
                valueMaked.Append(match.Groups[1].Value + ".");
                valueMaked.Append(match.Groups[2].Value + ".");
                valueMaked.Append(match.Groups[3].Value + "/");
                valueMaked.Append(match.Groups[4].Value + "-");
                valueMaked.Append(match.Groups[5].Value);
                break;
            }

            return valueMaked.ToString();
        }
    }
}
