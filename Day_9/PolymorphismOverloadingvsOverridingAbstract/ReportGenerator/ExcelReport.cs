using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismOverloadingvsOverridingAbstract.ReportGenerator
{
    internal class ExcelReport : AbstractReportGeneratorClass
    {
        // GenetaeReport implements
        public override void GenerateReport()
        {
            Console.WriteLine("Generate Excel Report....");
        }
    }
}
