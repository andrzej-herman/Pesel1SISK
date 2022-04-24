namespace Domain;

public static class PeselLogic
{
    public static string GenererateDatePart(DateTime dateofBirth)
    {
        var yPart = dateofBirth.Year.ToString().Substring(2, 2);
        var dPart = dateofBirth.Day.ToString("00");
        var mPart = dateofBirth.Year switch
        {
            >= 1900 and <= 1999 => dateofBirth.Month.ToString("00"),
            >= 2000 and <= 2099 => (dateofBirth.Month + 20).ToString(),
            _ => null
        };

        return mPart == null ? null : $"{yPart}{mPart}{dPart}";
    }
    
    public static string GenererateOrderPart(int currentIndex)
    {
        return (currentIndex + 1).ToString("000");
    }
    
    public static string GenererateControlDigit(string currentPesel)
    {
        var wages = new List<int>() {1, 3, 7, 9, 1, 3, 7, 9, 1, 3};
        var values = new List<int>();
        for (var idx = 0; idx < 10; idx++)
        {
            values.Add(wages[idx] * int.Parse(currentPesel[idx].ToString()));
        }

        var digits = values.Select(item => item.ToString().Length == 1 
            ? item : int.Parse(item.ToString().Substring(1, 1))).ToList();

        var sum = digits.Sum();
        return sum.ToString().Length == 1 
            ? (10 - sum).ToString() : 
            (10 - int.Parse(sum.ToString().Substring(1, 1))).ToString();
    }
}