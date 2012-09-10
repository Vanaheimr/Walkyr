﻿/*
 * Copyright (c) 2010-2012, Achim 'ahzf' Friedland <achim@graph-database.org>
 * This file is part of Walkyr <http://www.github.com/Vanaheimr/Walkyr>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;

using de.ahzf.Vanaheimr.Blueprints;

#endregion

namespace de.ahzf.Vanaheimr.Walkyr
{

    /// <summary>
    /// An abstract graph serializer.
    /// </summary>
    /// <typeparam name="TIdVertex">The type of the vertex identifiers.</typeparam>
    /// <typeparam name="TRevIdVertex">The type of the vertex revision identifiers.</typeparam>
    /// <typeparam name="TVertexLabel">The type of the vertex type.</typeparam>
    /// <typeparam name="TKeyVertex">The type of the vertex property keys.</typeparam>
    /// <typeparam name="TValueVertex">The type of the vertex property values.</typeparam>
    /// 
    /// <typeparam name="TIdEdge">The type of the edge identifiers.</typeparam>
    /// <typeparam name="TRevIdEdge">The type of the edge revision identifiers.</typeparam>
    /// <typeparam name="TEdgeLabel">The type of the edge label.</typeparam>
    /// <typeparam name="TKeyEdge">The type of the edge property keys.</typeparam>
    /// <typeparam name="TValueEdge">The type of the edge property values.</typeparam>
    /// 
    /// <typeparam name="TIdMultiEdge">The type of the multiedge identifiers.</typeparam>
    /// <typeparam name="TRevIdMultiEdge">The type of the multiedge revision identifiers.</typeparam>
    /// <typeparam name="TMultiEdgeLabel">The type of the multiedge label.</typeparam>
    /// <typeparam name="TKeyMultiEdge">The type of the multiedge property keys.</typeparam>
    /// <typeparam name="TValueMultiEdge">The type of the multiedge property values.</typeparam>
    /// 
    /// <typeparam name="TIdHyperEdge">The type of the hyperedge identifiers.</typeparam>
    /// <typeparam name="TRevIdHyperEdge">The type of the hyperedge revision identifiers.</typeparam>
    /// <typeparam name="THyperEdgeLabel">The type of the hyperedge label.</typeparam>
    /// <typeparam name="TKeyHyperEdge">The type of the hyperedge property keys.</typeparam>
    /// <typeparam name="TValueHyperEdge">The type of the hyperedge property values.</typeparam>
    /// 
    /// <typeparam name="TReturnFormat">The return format of the serializer.</typeparam>
    public abstract class AGraphSerializer<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                           TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                           TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                           TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge,
                                           TReturnFormat>

            : IGraphSerializer<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                               TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                               TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                               TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge,
                               TReturnFormat>

        where TIdVertex        : IEquatable<TIdVertex>,       IComparable<TIdVertex>,       IComparable, TValueVertex
        where TIdEdge          : IEquatable<TIdEdge>,         IComparable<TIdEdge>,         IComparable, TValueEdge
        where TIdMultiEdge     : IEquatable<TIdMultiEdge>,    IComparable<TIdMultiEdge>,    IComparable, TValueMultiEdge
        where TIdHyperEdge     : IEquatable<TIdHyperEdge>,    IComparable<TIdHyperEdge>,    IComparable, TValueHyperEdge

        where TRevIdVertex     : IEquatable<TRevIdVertex>,    IComparable<TRevIdVertex>,    IComparable, TValueVertex
        where TRevIdEdge       : IEquatable<TRevIdEdge>,      IComparable<TRevIdEdge>,      IComparable, TValueEdge
        where TRevIdMultiEdge  : IEquatable<TRevIdMultiEdge>, IComparable<TRevIdMultiEdge>, IComparable, TValueMultiEdge
        where TRevIdHyperEdge  : IEquatable<TRevIdHyperEdge>, IComparable<TRevIdHyperEdge>, IComparable, TValueHyperEdge

        where TVertexLabel     : IEquatable<TVertexLabel>,    IComparable<TVertexLabel>,    IComparable, TValueVertex
        where TEdgeLabel       : IEquatable<TEdgeLabel>,      IComparable<TEdgeLabel>,      IComparable, TValueEdge
        where TMultiEdgeLabel  : IEquatable<TMultiEdgeLabel>, IComparable<TMultiEdgeLabel>, IComparable, TValueMultiEdge
        where THyperEdgeLabel  : IEquatable<THyperEdgeLabel>, IComparable<THyperEdgeLabel>, IComparable, TValueHyperEdge

        where TKeyVertex       : IEquatable<TKeyVertex>,      IComparable<TKeyVertex>,      IComparable
        where TKeyEdge         : IEquatable<TKeyEdge>,        IComparable<TKeyEdge>,        IComparable
        where TKeyMultiEdge    : IEquatable<TKeyMultiEdge>,   IComparable<TKeyMultiEdge>,   IComparable
        where TKeyHyperEdge    : IEquatable<TKeyHyperEdge>,   IComparable<TKeyHyperEdge>,   IComparable

    {

        #region Properties

        #region IncludePropertyTypes

        /// <summary>
        /// Wether the property types should be included or not.
        /// </summary>
        public Boolean IncludePropertyTypes { get; private set; }

        #endregion

        #region IgnoreUnknownPropertyTypes

        /// <summary>
        /// Wether to ignore properties with unknown property types.
        /// </summary>
        public Boolean IgnoreUnknownPropertyTypes { get; private set; }

        #endregion

        #region IncludeMultiAndHyperEdges

        /// <summary>
        /// Wether the multi- and hyperedges should be included or not.
        /// </summary>
        public Boolean IncludeMultiAndHyperEdges { get; private set; }

        #endregion

        #endregion

        #region Constructor(s)

        #region ASerializer(IncludePropertyTypes = false, IgnoreUnknownPropertyTypes = false, IncludeMultiAndHyperEdges = false)

        /// <summary>
        /// Creates a new abstract serializer.
        /// </summary>
        /// <param name="IncludePropertyTypes">Wether the property types should be included or not.</param>
        /// <param name="IgnoreUnknownPropertyTypes">Wether to ignore properties with unknown property types.</param>
        /// <param name="IncludeMultiAndHyperEdges">Wether the multi- and hyperedges should be included or not.</param>
        public AGraphSerializer(Boolean IncludePropertyTypes       = false,
                           Boolean IgnoreUnknownPropertyTypes = false,
                           Boolean IncludeMultiAndHyperEdges  = false)
        {

            this.IncludePropertyTypes       = IncludePropertyTypes;
            this.IgnoreUnknownPropertyTypes = IgnoreUnknownPropertyTypes;
            this.IncludeMultiAndHyperEdges  = IncludeMultiAndHyperEdges;

        }

        #endregion

        #endregion


        #region (virtual) ObjectSerializer(Object Object)

        /// <summary>
        /// Serializes the given Object.
        /// </summary>
        /// <param name="Object">An Object.</param>
        /// <returns>The serialized Object.</returns>
        protected virtual TReturnFormat ObjectSerializer(Object Object)
        {
            return default(TReturnFormat);
        }

        #endregion


        #region (abstract) Serialize(Graph)

        /// <summary>
        /// Serialize the given graph.
        /// </summary>
        /// <param name="Graph">A graph.</param>
        public abstract TReturnFormat Serialize(IReadOnlyGenericPropertyGraph<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                                              TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                                              TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                                              TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Graph);

        #endregion

        #region (abstract) Serialize(Vertex)

        /// <summary>
        /// Serialize the given vertex.
        /// </summary>
        /// <param name="Vertex">A vertex.</param>
        public abstract TReturnFormat Serialize(IReadOnlyGenericPropertyVertex<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                                               TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                                               TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                                               TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Vertex);

        #endregion

        #region (abstract) Serialize(Edge)

        /// <summary>
        /// Serialize the given edge.
        /// </summary>
        /// <param name="Edge">A edge.</param>
        public abstract TReturnFormat Serialize(IReadOnlyGenericPropertyEdge<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                                             TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                                             TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                                             TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Edge);

        #endregion

        #region (abstract) Serialize(MultiEdge)

        /// <summary>
        /// Serialize the given multiedge.
        /// </summary>
        /// <param name="MultiEdge">A multiedge.</param>
        public abstract TReturnFormat Serialize(IReadOnlyGenericPropertyMultiEdge<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                                                  TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                                                  TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                                                  TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> MultiEdge);

        #endregion

        #region (abstract) Serialize(HyperEdge)

        /// <summary>
        /// Serialize the given hyperedge.
        /// </summary>
        /// <param name="HyperEdge">A hyperedge.</param>
        public abstract TReturnFormat Serialize(IReadOnlyGenericPropertyHyperEdge<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                                                  TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                                                  TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                                                  TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> HyperEdge);

        #endregion

    }

}
