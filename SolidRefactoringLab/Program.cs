using System;

namespace SolidRefactoringLab
{
    // ---------- OCP: abstraction + implementations ----------

    public interface IReportFormatter
    {
        void FormatReport();
    }

    public class PdfFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a PDF...");
        }
    }

    public class WordFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a Word Document...");
        }
    }

    public class PlainTextFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as plain text...");
        }
    }

    // ---------- SRP: saving is its own responsibility ----------

    public class ReportSaver
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}...");
        }
    }

    // ---------- ReportManager: only coordinates formatting ----------

    public class ReportManager
    {
        private readonly IReportFormatter _formatter;

        public string ReportData { get; set; } = string.Empty;

        // Dependency Injection via constructor
        public ReportManager(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void GenerateReport()
        {
            _formatter.FormatReport();
        }
    }

    class Program
    {
        static void Main(string[] args)
    {
      // 1. Choose the formatter (OCP)
    IReportFormatter formatter = new PdfFormatter();

    // 2. Pass it to the manager
    ReportManager manager = new ReportManager(formatter);
    manager.GenerateReport();

    // 3. Use the dedicated saver (SRP)
    ReportSaver saver = new ReportSaver();
    saver.SaveToFile("Q1_Report.pdf");
        }
    }
}