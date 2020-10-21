using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Viewer.VM
{
    public class FileInformation
    {
        public string FileName { get;set;}
        public long SumOfBytes { get;set;}
        public FileInformation(string fileName, long sumOfBytes)
        {
            FileName = fileName;
            SumOfBytes = sumOfBytes;
        }
    }
}
