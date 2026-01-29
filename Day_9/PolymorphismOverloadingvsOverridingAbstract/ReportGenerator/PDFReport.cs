using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismOverloadingvsOverridingAbstract.ReportGenerator
{
    internal class PDFReport : AbstractReportGeneratorClass
    {
        // GenetaeReport implements
        public override void GenerateReport()
        {
            Console.WriteLine("Generate PDF Report....");
        }
    }
}
