using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ecueditor.com.Interfaces;

namespace ecueditor.com.BaseClasses
{
    public class m32rBase : IBinFile
    {
        #region Constructors

        public m32rBase()
        {
        }

        public m32rBase(string filePath)
        {
            //ToDo: load bin file from filePath
        }

        #endregion

        #region Properties

        public virtual string ECUID
        {
            get 
            { 
                throw new NotImplementedException(); 
            }
        }

        public virtual string Model
        {
            get 
            { 
                throw new NotImplementedException(); 
            }
        }

        #endregion
    }
}