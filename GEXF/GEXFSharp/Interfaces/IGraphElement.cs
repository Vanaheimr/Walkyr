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

    /// <summary>
    /// Common interface for INode and IEdge
    /// </summary>
    public interface IGraphElement //, SlicableDatum<IGraphElement>
    {

        /// <summary>
        /// A unique indentification for nodes and edges
        /// </summary>
	    String  Id      { get; }

        /// <summary>
        /// A short label or description of a node or edge
        /// </summary>
        String  Label   { get; set; }

        /// <summary>
        /// The color of this node or edge used for visualization
        /// </summary>
        IColor  Color   { get; set; }

    }

}
