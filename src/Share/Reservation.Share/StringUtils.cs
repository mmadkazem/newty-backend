namespace Reservation.Share;
public static class StringUtils
{
    public static string GetUniqueKey(int size)
    {
        byte[] data = new byte[4 * size];
        var chars = "1234567890".ToCharArray();
        using (var crypto = RandomNumberGenerator.Create())
        {
            crypto.GetBytes(data);
        }
        StringBuilder result = new(size);
        for (int i = 0; i < size; i++)
        {
            var rnd = BitConverter.ToUInt32(data, i * 4);
            var idx = rnd % chars.Length;

            result.Append(chars[idx]);
        }

        return result.ToString();
    }

    public static string CreateCryptographicallySecureGuid()
    {
        var _rand = RandomNumberGenerator.Create();
        var bytes = new byte[16];
        _rand.GetBytes(bytes);
        return new Guid(bytes).ToString();
    }
    public static string GenerateTrackId(int length)
    {
        StringBuilder myGuidLikeString = new StringBuilder();
        while (myGuidLikeString.Length < length)
        {
            myGuidLikeString.Append(Guid.NewGuid().ToString().Replace("-", ""));
        }
        return myGuidLikeString.ToString(0, length);
    }

    public static string SubStringText(string inputText, int startIndex, int length)
    {
        var strText = inputText;

        if (strText.Length > length)
        {
            return strText.Substring(startIndex, length) + " ... ";
        }
        else
        {
            return strText;
        }
    }

    public static string GetRightMobileNumber(string phone)
    {
        if (phone == null) return null;

        var number = phone.Replace("+", "")
            .Replace(" ", "")
            .Replace("(", "")
            .Replace(")", "")
            .Replace("-", "")
            .Replace("۰", "0")
            .Replace("۱", "1")
            .Replace("۲", "2")
            .Replace("۳", "3")
            .Replace("۴", "4")
            .Replace("۵", "5")
            .Replace("۶", "6")
            .Replace("۷", "7")
            .Replace("۸", "8")
            .Replace("۹", "9")
            .TrimStart('0');

        if (number.Length < 10) return null;

        number = number.Substring(number.Length - 10, 10);
        if (number.Substring(0, 1) != "9") return null;

        try
        {
            Int64.Parse(number);
        }
        catch (Exception)
        {
            return null;
        }
        return "0" + number;
    }

    public static bool IsValidEmail(string s)
    {
        if (string.IsNullOrEmpty(s)) return false;
        return Regex.IsMatch(s, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
    }

    public static bool IsValidPhone(string s)
    {
        if (string.IsNullOrEmpty(s)) return false;
        return (!string.IsNullOrEmpty(GetRightMobileNumber(s)));
    }
    public static bool IsCensoredWords(string word)
    {
        var values = word.Split(" ");
        foreach (var value in values)
        {
            if (CensoredWords.Any(c => c == value))
            {
                return false;
            }
        }
        return true;
    }



    #region CensorText
    public static IList<string> CensoredWords = new List<string>()
    {
        "sex","داف","شهوتی","کس دادن","کوس","کون دادن","کون کردن","کونکش","لخت","لختی","کس شر",
        "fuck","porn","نفوذ","سکس","کون","کرک","کس کش","هرزه","هک","ارگاسم","تجاوز","جلق",
        "جقی","جنده","چوچول","دودول","ساک زدن","کس کن","کس کردن","فیلم سوپر","کس دادن","کیر",
        "کس کش","تجاوز","تخمی","حشر","حشری","لاپا","لاشی","سوپر","شهوت","سکسی","sexy","sexi",
        "کونی","کیری","لاپایی","حرومزاده","hack","crack","bet","kir","kos","sighe","shaparak","shap","tajavoz"
        ,"koni","harze","shart","shartbandi","ghomar","gamble","sigheyab","pussy","dick","cock","ass","hot"
        ,"nude","pishbini", "کص", "کس", "string"
    };
    #endregion
}