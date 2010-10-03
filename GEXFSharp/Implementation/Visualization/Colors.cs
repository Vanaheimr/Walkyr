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

#endregion

namespace GEXFSharp
{

    public static class Colors
    {

        public static Tuple<Byte, Byte, Byte> BLACK     = new Tuple<Byte, Byte, Byte>(  0,   0,   0);
	    public static Tuple<Byte, Byte, Byte> RED       = new Tuple<Byte, Byte, Byte>(255,   0,   0);
        public static Tuple<Byte, Byte, Byte> GREEN     = new Tuple<Byte, Byte, Byte>(  0, 255,   0);
        public static Tuple<Byte, Byte, Byte> BLUE      = new Tuple<Byte, Byte, Byte>(  0,   0, 255);
        public static Tuple<Byte, Byte, Byte> YELLOW    = new Tuple<Byte, Byte, Byte>(255, 255,   0);
        public static Tuple<Byte, Byte, Byte> WHITE     = new Tuple<Byte, Byte, Byte>(255, 255, 255);

    }

}
