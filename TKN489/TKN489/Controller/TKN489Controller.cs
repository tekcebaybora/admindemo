using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TKN489.UserController;

namespace TKN489.Controller
{
    public class TKN489Controller
    {
        ITKN489View _view;
    
        public TKN489Controller(ITKN489View view)
        {
            _view = view;
            _view.SetController(this);
        }
        public TKN489Controller()
        {

        }
        public bool CheckDigit(string text)
        {
            String str = text.Trim();
            int Index;
            bool isNumber = Int32.TryParse(str, out Index);
            if (isNumber)
                return true;
            else
                return false;
        }

        public bool CheckDigitPositive(string text)
        {
            String str = text.Trim();
            int Index;
            bool isNumber = Int32.TryParse(str, out Index);
            if (isNumber && Index>0)
                return true;
            else
                return false;
        }

    }
}
