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

    public class Edge : ASliceableDatum<Edge>, IEdge
    {

        #region Properties

        public String    Id        { get; protected set; }
        public INode     Source    { get; protected set; }
        public INode     Target    { get; protected set; }
        public EdgeType  EdgeType  { get; set; }

        public String    Label     { get; set; }
        public IColor    Color     { get; set; }
        public float     Weight    { get; set; }
        public float     Thickness { get; set; }
        public EdgeShape Shape     { get; set; }

        #endregion

        #region Constructor(s)

        #region Edge(myId, mySource, myTarget, myLabel = null, myEdgeType = EdgeType.DIRECTED)

        public Edge(String   myId,
                    INode    mySource,
                    INode    myTarget,
                    String   myLabel     = null,
                    EdgeType myEdgeType  = EdgeType.DIRECTED)
        {

            if (myId.IsNullOrEmpty())
                throw new ArgumentNullException("myId must not be null or empty!");

            if (mySource == null)
                throw new ArgumentNullException("mySource must not be null!");

            if (myTarget == null)
                throw new ArgumentNullException("myTarget must not be null!");

            Id       = myId;
            Source   = mySource;
            Target   = myTarget;
            EdgeType = myEdgeType;

            // Attributes
            Label    = myLabel ?? myId;
            Weight   = 1;
            Shape    = EdgeShape.NOTSET;

        }

        #endregion

        #endregion


        #region GetSelf()

        protected override Edge GetSelf()
        {
            return this;
        }

        #endregion


        #region ToString()

        public override String ToString()
        {
            return String.Format("{0} [{1}]", Id, Label);
        }

        #endregion


    }

}
