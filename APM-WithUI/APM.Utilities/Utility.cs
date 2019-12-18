using System;
using System.IO;
using System.Text.RegularExpressions;

namespace APM.SL
{
  public static class Utility
  {
    public static bool SendEmail(string recipient, string subject,
                          string body, DateTime sendDate,
                          bool saveCopy = false, bool highPriority = false,
                          bool includeSignature = true)
    {
      // Send email
      Utility.LogToFile(new string[] { "Email sent:", recipient, subject, body, sendDate.ToShortDateString(),
                  saveCopy.ToString(), highPriority.ToString(), includeSignature.ToString() });

      return true;
    }

    public static void LogToFile(string[] textToLog)
    {
      string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

      if (String.IsNullOrEmpty(docPath)) throw new InvalidOperationException("Path cannot be null");

      using (StreamWriter w = File.AppendText(Path.Combine(docPath, "log.txt")))
      {
        w.WriteLine("");
        w.Write("Log Entry: ");
        w.WriteLine($"{DateTime.Now.ToLongTimeString()}");
        foreach (var logText in textToLog)
          w.WriteLine($" - {logText}");
        w.WriteLine("-------------------------------");
      }
    }

    public static string RemoveParenthetical(this String text)
    {
      return Regex.Replace(text, @"\(.*\)", "");
    }
  }
}
