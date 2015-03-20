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

    public class GEXF : IGEXF
    {

        #region Data

        private const String VERSION = "1.1";

        #endregion

        #region Properties

        #region Version

        public String Version
        {
            get
            {
                return VERSION;
            }
        }

        #endregion

        public IGraph    Graph         { get; protected set; }
        public IMetadata Metadata      { get; protected set; }
        public String    Variant       { get; set; }
        public Boolean   Visualization { get; set; }

        #endregion

        #region Constructor(s)

        public GEXF()
        {
            Graph         = new Graph();
            Metadata      = new Metadata();
            Variant       = null;
            Visualization = false;
        }

        #endregion


    }

}
