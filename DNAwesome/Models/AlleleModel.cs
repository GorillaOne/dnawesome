﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNAwesome.Models
{
    public class AlleleModel : Model
    {
        /// <summary>
        /// Lower = more dominant. 
        /// High = more recessive. 
        /// </summary>
        public int GeneOrder; 
    }
}
