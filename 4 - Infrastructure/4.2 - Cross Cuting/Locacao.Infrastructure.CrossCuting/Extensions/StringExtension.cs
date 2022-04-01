using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Locacao.Infrastructure.CrossCuting.Extensions
{
    public static class StringExtension
    {
        public static string RemoveFirstAndLastSlash(this String str)
        {
            if (str.EndsWith("/"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            if (str.StartsWith("/"))
            {
                str = str.Substring(1, str.Length - 1);
            }


            return str;
        }

        public static string RemoveFileNameExtension(this String str)
        {
            return String.IsNullOrEmpty(str) ? str : str.Split('.')[0];
        }

        public static string RemoveMaskCpfCnpj(this String str)
        {
            return Regex.Replace(str, @"[*/.-]", string.Empty).Trim();
        }

        public static string RemoveMaskPlaca(this String str) {
            return Regex.Replace(str, @"[?^\W_]", string.Empty).Trim();
        }


        public static string Compress(this String str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                var buffer = Encoding.UTF8.GetBytes(str);
                var memoryStream = new MemoryStream();
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gZipStream.Write(buffer, 0, buffer.Length);
                }

                memoryStream.Position = 0;

                var compressedData = new byte[memoryStream.Length];
                memoryStream.Read(compressedData, 0, compressedData.Length);

                var gZipBuffer = new byte[compressedData.Length + 4];
                Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
                Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
                return Convert.ToBase64String(gZipBuffer);
            }
            else
                return string.Empty;
        }

        public static string Decompress(this String str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                byte[] gZipBuffer = Convert.FromBase64String(str);
                using (var memoryStream = new MemoryStream())
                {
                    int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                    memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                    var buffer = new byte[dataLength];

                    memoryStream.Position = 0;
                    using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        gZipStream.Read(buffer, 0, buffer.Length);
                    }

                    return Encoding.UTF8.GetString(buffer);
                }
            }
            else
                return string.Empty;
        }

        public static string GetOnlyNumbers(this string str)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(str))
            {
                Regex r = new Regex(@"\d+");
                foreach (Match m in r.Matches(str))
                    result += m.Value;
            }

            return result;
        }

        public static string MaskCpf(this string cpf)
        {
            string result = cpf.Trim();

            if (!string.IsNullOrWhiteSpace(cpf) && cpf.Trim().Length == 11)
                result = cpf.Trim().Substring(0, 3) + "." + cpf.Trim().Substring(3, 3) + "." + cpf.Trim().Substring(6, 3) + "-" + cpf.Trim().Substring(9, 2);

            return result;
        }

        public static string MaskCnpj(this string cnpj)
        {
            string result = cnpj.Trim();

            if (!string.IsNullOrWhiteSpace(cnpj) && cnpj.Trim().Length == 14)
                result = cnpj.Trim().Substring(0, 2) + "." + cnpj.Trim().Substring(2, 3) + "." + cnpj.Trim().Substring(5, 3) + "/" + cnpj.Trim().Substring(8, 4) + "-" + cnpj.Trim().Substring(12, 2);

            return result;
        }

        public static string CreateMaskCpfCnpj(string cpfCnpj)
        {
            if (!string.IsNullOrEmpty(cpfCnpj))
            {
                string auxCpfCnpj = cpfCnpj.GetOnlyNumbers();
                cpfCnpj = auxCpfCnpj.Length == 11 ? auxCpfCnpj.MaskCpf() : auxCpfCnpj.Length == 14 ? auxCpfCnpj.MaskCnpj() : cpfCnpj;
            }

            return cpfCnpj;
        }

        public static string MaskCpfCnpj(this string cpfCnpj)
        {
            if (!string.IsNullOrEmpty(cpfCnpj))
            {
                string auxCpfCnpj = cpfCnpj.GetOnlyNumbers();
                cpfCnpj = auxCpfCnpj.Length == 11 ? auxCpfCnpj.MaskCpf() : auxCpfCnpj.Length == 14 ? auxCpfCnpj.MaskCnpj() : cpfCnpj;
            }

            return cpfCnpj;
        }

        public static bool IsCpfCnpjValidate(this string cpfCnpj)
        {
            return CnpjValidate(cpfCnpj) || CpfValidate(cpfCnpj);
        }


        public static bool IsCpfCnpj(this string cpfCnpj)
        {
            if (!string.IsNullOrEmpty(cpfCnpj))
            {
                return IsCpf(cpfCnpj) || IsCnpj(cpfCnpj);
            }
            return false;
        }

        public static bool CpfValidate(this string cpfCnpj)
        {
            if (IsCpf(cpfCnpj))
            {
                return validateCPF(ref cpfCnpj);
            }

            return false;
        }

        public static bool IsCpf(this string cpfCnpj)
        {
            if (!string.IsNullOrEmpty(cpfCnpj))
            {
                string auxCpfCnpj = cpfCnpj.GetOnlyNumbers();

                if (auxCpfCnpj.Length != 11)
                    return false;

                auxCpfCnpj = auxCpfCnpj.MaskCpf();

                Regex regex = new Regex(@"\d\d\d\.\d\d\d\.\d\d\d\-\d\d");

                Match match = regex.Match(auxCpfCnpj);
                if (match.ToString() != auxCpfCnpj)
                {
                    return false;
                }

                return true;

            }

            return false;
        }

        public static bool CnpjValidate(this string cpfCnpj)
        {
            if (IsCnpj(cpfCnpj))
            {
                return validateCPNJ(ref cpfCnpj);
            }

            return false;
        }

        public static bool IsCnpj(this string cpfCnpj)
        {
            if (!string.IsNullOrEmpty(cpfCnpj))
            {
                string auxCpfCnpj = cpfCnpj.GetOnlyNumbers();

                if (auxCpfCnpj.Length != 14)
                    return false;

                auxCpfCnpj = auxCpfCnpj.MaskCnpj();

                Regex regex = new Regex(@"\d\d\.\d\d\d\.\d\d\d\/\d\d\d\d\-\d\d");

                Match match = regex.Match(auxCpfCnpj);
                if (match.ToString() != auxCpfCnpj)
                {
                    return false;
                }

                return true;

            }

            return false;
        }

        public static bool IsCep(this string text) =>
            new Regex(@"^(\d{5})(-?)(\d{3})$").IsMatch(text);

        public static string MaskTelefone(this string telefone)
        {
            string result = telefone;

            telefone = telefone.GetOnlyNumbers();

            if (!string.IsNullOrWhiteSpace(telefone) && telefone.Length >= 10 && telefone.Length <= 11)
            {
                var isFiveDigits = telefone.Length == 11;
                result = "(" + telefone.Substring(0, 2) + ") " + telefone.Substring(2, (isFiveDigits ? 5 : 4)) + "-" + telefone.Substring(telefone.Length - 4);
            }

            return result;
        }

        public static string RemoveSpecialCharacters(this string field)
        {
            if (String.IsNullOrEmpty(field))
            {
                field = string.Empty;
                return field;
            }
            var arrayField = field.ToArray();
            var arraySpecialCharacters = "1234567890ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ!\"#$%&()*+,-./:;<=>?@[\\]^_`{|}~€ƒ„…†‡ˆ‰Š‹ŒŽ‘’“”•–—˜™š›œžŸ¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿''";
            var arrayToReplace = "1234567890AAAAAAACEEEEIIIIDNOOOOOOOUUUUYUBaaaaaaaceeeeiiiionooooooouuuuyuy                                 F      S  Z            zY                                  ";

            for (int i = 0; i < field.Length; i++)
            {
                if (arraySpecialCharacters.Contains(arrayField[i]))
                {
                    arrayField[i] = arrayToReplace[arraySpecialCharacters.IndexOf(arrayField[i])];
                }
            }
            field = new string(arrayField).ToUpper();
            return field;
        }

        public static string removerAcentos(this string texto)
        {
            if (String.IsNullOrEmpty(texto))
            {
                texto = string.Empty;
                return texto;
            }

            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        }

        public static string MaskCep(this string cep)
        {
            if (!string.IsNullOrEmpty(cep) && cep.Trim().Length == 8)
                cep = Convert.ToUInt64(cep).ToString(@"00000\-000");

            return cep;
        }

        public static string CleanIntegrationMessage(this string value)
        {
            var strReturn = string.Empty;

            if (!string.IsNullOrWhiteSpace(value))
            {
                var jsonMessage = JsonConvert.DeserializeObject(new Regex(@"\{[^/}]+?\}").Match(value).Value);
                var valueMessage = ((Newtonsoft.Json.Linq.JValue)(((Newtonsoft.Json.Linq.JProperty)((Newtonsoft.Json.Linq.JContainer)jsonMessage).First).Value)).Value;

                if (valueMessage != null)
                    strReturn = valueMessage.ToString();
            }

            return strReturn;
        }

        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static bool ValidateEmail(this String str)
        {
            return Regex.IsMatch(str, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        private static bool validateCPF(ref string cpf)
        {
            cpf = cpf.Replace("-", string.Empty).Replace(".", string.Empty);

            var exceptionCPFList = new string[] { "00000000000", "11111111111", "22222222222", "33333333333",
                "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };

            if (exceptionCPFList.ToList().Contains(cpf))
                return false;

            string verification = cpf[9].ToString(CultureInfo.InvariantCulture) + cpf[10].ToString(CultureInfo.InvariantCulture);

            int firstVerificationDigit = 0;
            int secondVerificationDigit = 0;
            for (int i = 0; i < 9; ++i)
            {
                firstVerificationDigit += int.Parse(string.Empty + cpf[i].ToString(CultureInfo.InvariantCulture)) * (10 - i);
                secondVerificationDigit += int.Parse(string.Empty + cpf[i].ToString(CultureInfo.InvariantCulture)) * (11 - i);
            }

            firstVerificationDigit = 11 - (firstVerificationDigit % 11);
            firstVerificationDigit = firstVerificationDigit >= 10 ? 0 : firstVerificationDigit;
            secondVerificationDigit += 2 * firstVerificationDigit;
            secondVerificationDigit = 11 - (secondVerificationDigit % 11);
            secondVerificationDigit = secondVerificationDigit >= 10 ? 0 : secondVerificationDigit;
            return firstVerificationDigit == int.Parse(string.Empty + verification[0].ToString(CultureInfo.InvariantCulture)) && secondVerificationDigit == int.Parse(verification[1].ToString(CultureInfo.InvariantCulture));
        }

        private static bool validateCPNJ(ref string cnpj)
        {
            var exceptionCnpjList = new string[] { "00000000000000", "11111111111111", "22222222222222", "33333333333333",
                "44444444444444", "55555555555555", "66666666666666", "77777777777777", "88888888888888", "99999999999999" };

            int[] conj1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] conj2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tudo = string.Empty;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);

            if (cnpj.Length != 14) return false;

            if (exceptionCnpjList.ToList().Contains(cnpj))
                return false;

            string cnpjtemporario = cnpj.Substring(0, 12);
            int scale = 0;
            for (int i = 0; i < 12; i++)
                scale += int.Parse(cnpjtemporario[i].ToString(CultureInfo.InvariantCulture)) * conj1[i];
            int restante = (scale % 11);
            if (restante < 2) restante = 0;
            else restante = 11 - restante;
            tudo = restante.ToString(CultureInfo.InvariantCulture);
            cnpjtemporario = cnpjtemporario + tudo;
            scale = 0;
            for (int i = 0; i < 13; i++)
                scale += int.Parse(cnpjtemporario[i].ToString(CultureInfo.InvariantCulture)) * conj2[i];
            restante = (scale % 11);
            if (restante < 2) restante = 0;
            else restante = 11 - restante;
            tudo = tudo + restante.ToString(CultureInfo.InvariantCulture);
            return cnpj.EndsWith(tudo);
        }
        public static bool EqualIgnoreCase(this string s1, string s2)
        {
            return s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase);
        }

        public static int? TryParseInt(this string s)
        {
            if (int.TryParse(s, out int result))
                return result;
            return null;
        }
        public static bool ValidarPlaca(this string placa)
        {
            placa = RemoveMaskPlaca(placa);

            if (string.IsNullOrEmpty(placa)) { return false; }

            if (placa.Length > 8) { return false; }

            /*
             *  Verifica se o caractere da posição 4 é uma letra, se sim, aplica a validação para o formato de placa do Mercosul,
             *  senão, aplica a validação do formato de placa padrão.
             */
            if (char.IsLetter(placa, 4))
            {
                /*
                 *  Verifica se a placa está no formato: três letras, um número, uma letra e dois números.
                 */
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                // Verifica se os 3 primeiros caracteres são letras e se os 4 últimos são números.
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }

    }
}
