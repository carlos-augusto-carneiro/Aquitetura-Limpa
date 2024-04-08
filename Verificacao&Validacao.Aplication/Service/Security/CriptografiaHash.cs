using System.Security.Cryptography;
using System.Text;

namespace Verificacao_Validacao.Aplication.Service.Security
{
    public static class CriptografiaHash
    {
        public static string GerarHash(this string Valor)
        {
            if (string.IsNullOrEmpty(Valor))
            {
                throw new ArgumentException("O valor não pode ser nulo ou vazio.", nameof(Valor));
            }

            var hash = SHA256.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(Valor);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
