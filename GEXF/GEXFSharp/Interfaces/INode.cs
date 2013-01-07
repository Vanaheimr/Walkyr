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
using System.Collections.Generic;

#endregion

namespace GEXFSharp
{

    public interface INode : IGraphElement //, SlicableDatum<INode>
    {

        /// <summary>
        /// Returns all edges starting at this node
        /// </summary>
        IEnumerable<IEdge>  Edges       { get; }


        /// <summary>
        /// The position of this node for visualization
        /// </summary>
        IPosition           Position    { get; set; }

        /// <summary>
        /// The size of this node for visualization
        /// </summary>
        float               Size        { get; set; }

        /// <summary>
        /// The shape of this node for visualization
        /// </summary>
        INodeShape          Shape       { get; set; }

        /// <summary>
        /// The PID of this node
        /// </summary>
        String              PID         { get; set; }


        /// <summary>
        /// Connects this node with the given target node
        /// </summary>
        IEdge ConnectTo(INode myINodeTarget);

        /// <summary>
        /// Connects this node with the given target node.
        /// Uses the given EdgeId for creating a new edge.
        /// </summary>
        IEdge ConnectTo(String myEdgeId, INode myINodeTarget);

    }

}
