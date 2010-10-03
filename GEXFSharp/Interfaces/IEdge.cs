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

    public interface IEdge : IGraphElement //, SlicableDatum<IEdge>
    {

        /// <summary>
        /// The source node of this edge
        /// </summary>
        INode     Source    { get; }

        /// <summary>
        /// The target node of this edge
        /// </summary>
        INode     Target    { get; }

        /// <summary>
        /// Defines wether this edge is DIRECTED, UNDIRECTED or MUTUAL
        /// </summary>
        EdgeType  EdgeType  { get; set; }


        /// <summary>
        /// The weight of this edge
        /// </summary>
        float     Weight    { get; set; }

        /// <summary>
        /// The thickness of this edge used for visualization
        /// </summary>
        float     Thickness { get; set; }

        /// <summary>
        /// The shape of this edge used for visualization
        /// </summary>
        EdgeShape Shape     { get; set; }

    }

}
