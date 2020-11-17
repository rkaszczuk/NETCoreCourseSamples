using System;
using System.Collections.Generic;
using System.Text;

namespace _07_MethodChaining.Samples
{
    public static class MailBuilderSampleExt
    {
        public static MailBuilderSample GetBodyFromFile(this MailBuilderSample mailBuilderSample, string path)
        {
            var fileContent = System.IO.File.ReadAllText(path);
            return mailBuilderSample.SetBody(fileContent);
        }
    }
}
