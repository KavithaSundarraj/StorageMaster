using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.IO.Contracts
{
 public interface IWriter
    {
        public void display(String output);
        public void output();
    }
}
