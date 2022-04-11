using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromZero.Desktop.Domain.Models
{
    public class Attendance
    {
        #region Variables    
        private string _name = string.Empty;
        #endregion

        #region Properties    


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        #endregion
    }
}
