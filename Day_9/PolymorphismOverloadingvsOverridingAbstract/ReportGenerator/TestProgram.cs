using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismOverloadingvsOverridingAbstract.ReportGenerator
{
    internal class TestProgram    {
        static void Main()
        {
            // Two different Objects with base class referance
            AbstractReportGeneratorClass Obj = new PDFReport();
            AbstractReportGeneratorClass Obj2 = new ExcelReport();
            
            // To different method call via two different objects.
            Obj.GenerateReport();
            Obj2.GenerateReport();
        }
    }
}
