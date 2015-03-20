/*
 *  Licensed to the Apache Software Foundation (ASF) under one
 *  or more contributor license agreements.  See the NOTICE file
 *  distributed with this work for additional information
 *  regarding copyright ownership.  The ASF licenses this file
 *  to you under the Apache License, Version 2.0 (the
 *  "License"); you may not use this file except in compliance
 *  with the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing,
 *  software distributed under the License is distributed on an
 *  "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 *  KIND, either express or implied.  See the License for the
 *  specific language governing permissions and limitations
 *  under the License.
 *
 *  Autor: Achim Friedland <achim@graph-database.org>, 2010
 *
 */

#region Usings

using System;
using System.Text;

#endregion

namespace GEXFSharp
{

    public class Color : IColor
    {

        #region Constructor(s)

        #region Color()

        public Color()
        {
        }

        #endregion

        #region Color(myRed, myGreen, myBlue)

        public Color(Byte myRed, Byte myGreen, Byte myBlue)
        {
            Red   = myRed;
            Green = myGreen;
            Blue  = myBlue;
        }

        #endregion

        #region Color(myColorTriple)

        public Color(Tuple<Byte, Byte, Byte> myColorTriple)
        {
            Red   = myColorTriple.Item1;
            Green = myColorTriple.Item2;
            Blue  = myColorTriple.Item3;
        }

        #endregion

        #endregion

        #region Properties

        public Byte Red   { get; set; }
        public Byte Green { get; set; }
        public Byte Blue  { get; set; }

        #endregion

    }

}
