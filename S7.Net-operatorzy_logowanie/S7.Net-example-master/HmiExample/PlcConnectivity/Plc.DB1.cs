﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmiExample.PlcConnectivity
{
    public class DB3
    {
        /// <summary>
        /// DB3.DBX286.0
        /// </summary>
        public bool BitVariable0 { get; set; }
        public bool BitVariable1 { get; set; }
        public bool BitVariable2 { get; set; }
        public bool BitVariable3 { get; set; }
        public bool BitVariable4 { get; set; }
        public bool BitVariable5 { get; set; }
        public bool BitVariable6 { get; set; }
        public bool BitVariable7 { get; set; }

        /// <summary>
        /// DB3.DBX286.0
        /// </summary>
        public bool BitVariable10 { get; set; }
        public bool BitVariable11 { get; set; }
        public bool BitVariable12 { get; set; }
        public bool BitVariable13 { get; set; }
        public bool BitVariable14 { get; set; }
        public bool BitVariable15 { get; set; }
        public bool BitVariable16 { get; set; }
        public bool BitVariable17 { get; set; }

        /// <summary>
        /// DB3.DBW290
        /// </summary>
        public short IntVariable { get; set; }

        /// <summary>
        /// DB3.DBD312
        /// </summary>
        public double RealVariable { get; set; }

        /// <summary>
        /// DB3.DBD308
        /// </summary>
        public int DIntVariable { get; set; }

        /// <summary>
        /// DB1.DBD304
        /// </summary>
        public ushort DWordVariable { get; set; }
    }
}
