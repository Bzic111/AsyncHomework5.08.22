using System.Text.RegularExpressions;
using WebApiHW_8._08._22.Interfaces;


namespace WebApiHW_8._08._22.RegexRunner;

public class RegexRunner : IRegexRunner
{
    public RegexRunner()
    {

    }
    public string BasicClearString(string str)
    {
        // = " Предложение один Теперь предложение два Предложение три ";
        //Console.WriteLine(str);

        RegexOptions options = RegexOptions.None;
        Regex regex = new Regex("[ ]{2,}", options);
        string res = regex.Replace(str, " ");
        return res;
    }
}
