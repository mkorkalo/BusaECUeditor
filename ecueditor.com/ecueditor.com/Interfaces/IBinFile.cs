using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecueditor.com.Interfaces
{
    interface IBinFile
    {
        #region Properties

        string ECUID
        {
            get;
        }

        string Model
        {
            get;
        }

        #endregion
    }
}
