using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortuneTeller
{
    class Program
    {
        static void Main(string[] args)
        {
            WeekThree.ProjectDay FortuneTeller = new WeekThree.ProjectDay();
            while (true)
            {
                try
                {
                    FortuneTeller.Project();
                    break;
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
