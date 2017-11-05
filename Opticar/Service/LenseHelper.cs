using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Opticar.Service
{
    public class LenseHelper
    {
        public void SfereCylinderGenerator()
        {

            decimal mins = 0.25m;
            decimal minss = -6m;
            var maxs = 6m;
            var minc = 0m;
            var maxc = 2m;
            //Your code goes here
            Console.WriteLine("Hello, world!");
            var strlist = new List<string>();

            for (decimal j = minc; j <= maxc; j += 0.25m)
                for (decimal i = minss; i <= maxs; i += 0.25m)
                {
                    {

                        if ((i + j <= maxs) && (i + j >= mins))
                        {
                            var a = String.Format("c{0},s{1}", j, i);
                            strlist.Add(a);
                            Console.WriteLine("c{0}       s{1}", j, i);
                        }
                    }
                }

            Console.WriteLine(strlist.Count);
        }
    }
}