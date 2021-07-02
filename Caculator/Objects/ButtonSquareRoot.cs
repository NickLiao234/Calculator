using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    public class ButtonSquareRoot : ButtonBase
    {
        private readonly ISquareRootService squareRootService;

        public ButtonSquareRoot(ISquareRootService squareRootService)
        {
            this.squareRootService = squareRootService;
        }
        public override void Excute()
        {
            squareRootService.SquareRoot();
        }
    }
}
