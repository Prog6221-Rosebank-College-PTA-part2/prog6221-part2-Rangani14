using System.Collections.Generic;

public class NLPProcessor
{
    Dictionary<string, string> phrases =
        new Dictionary<string, string>()
    {
        {
            "how can i stay safe online",
            "Use strong passwords and avoid suspicious links."
        },

        {
            "i forgot my password",
            "Use the account recovery process and create a strong new password."
        },

        {
            "what is phishing",
            "Phishing is a scam where attackers try to steal information."
        }
    };

    public string ProcessInput(string input)
    {
        input = input.ToLower();

        foreach (var item in phrases)
        {
            if (input.Contains(item.Key))
            {
                return item.Value;
            }
        }

        return "";
    }
}