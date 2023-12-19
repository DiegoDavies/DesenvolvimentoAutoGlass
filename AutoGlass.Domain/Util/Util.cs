using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AutoGlass.Domain.Util
{
    public static class Util
    {
        public static bool DataValida(string date)
        {
            var valid1 = DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out DateTime newDate);
            var valid2 = DateTime.TryParseExact(date, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out DateTime newDate2);
            return valid1 || valid2;
        }

        public static DateTime FormatarData(string date)
        {
            var valid1 = DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out DateTime newDate);
            var valid2 = DateTime.TryParseExact(date, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out DateTime newDate2);

            if (valid1)
                return newDate;
            else if (valid2)
                return newDate2;
            else
                return DateTime.Now;
        }

        public static string MensagemFormatoDataInvalida { get; set; } = "não está no formato correto (31/12/2023 23:59:59 ou 31/12/2023)";
    }
}
