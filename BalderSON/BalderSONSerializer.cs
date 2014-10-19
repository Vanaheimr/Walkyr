/*
 * Copyright (c) 2010-2014, Achim 'ahzf' Friedland <achim@graphdefined.org>
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
using System.Linq;
using System.Text;
using System.Collections.Generic;

using org.GraphDefined.Vanaheimr.Illias;
using org.GraphDefined.Vanaheimr.Illias.Collections;
using org.GraphDefined.Vanaheimr.Balder;

#endregion

namespace org.GraphDefined.Vanaheimr.Walkyr.BalderSON
{

    /// <summary>
    /// A BalderSON graph serializer.
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
    public class BalderSONSerializer<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                     TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                     TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                     TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>

          : AStringGraphSerializer<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                   TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                   TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                   TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>

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

        #region Constructor(s)

        #region BalderSONSerializer(IncludePropertyTypes = false, IgnoreUnknownPropertyTypes = false, IncludeMultiAndHyperEdges = false)

        /// <summary>
        /// Creates a new BalderSON graph (de-)serializer.
        /// </summary>
        /// <param name="IncludePropertyTypes">Wether the property types should be included or not.</param>
        /// <param name="IgnoreUnknownPropertyTypes">Wether to ignore properties with unknown property types.</param>
        /// <param name="IncludeMultiAndHyperEdges">Wether the multi- and hyperedges should be included or not.</param>
        public BalderSONSerializer(Boolean                      IncludePropertyTypes         = false,
                                   Boolean                      IgnoreUnknownPropertyTypes   = false,
                                   Boolean                      IncludeMultiAndHyperEdges    = false,

                                   Func<TIdVertex,    String>   VertexIdSerializer           = null,
                                   Func<TIdEdge,      String>   EdgeIdSerializer             = null,
                                   Func<TIdMultiEdge, String>   MultiEdgeIdSerializer        = null,
                                   Func<TIdHyperEdge, String>   HyperEdgeIdSerializer        = null,

                                   Func<TKeyVertex,   String>   TKeyVertexSerializer         = null,
                                   Func<TValueVertex, String>   TValueVertexSerializer       = null,
                                   Func<TKeyEdge,     String>   TKeyEdgeSerializer           = null,
                                   Func<TValueEdge,   String>   TValueEdgeSerializer         = null)

            : base(IncludePropertyTypes,
                   IgnoreUnknownPropertyTypes,
                   IncludeMultiAndHyperEdges,

                   VertexIdSerializer,
                   EdgeIdSerializer,
                   MultiEdgeIdSerializer,
                   HyperEdgeIdSerializer,

                   TKeyVertexSerializer,
                   TValueVertexSerializer,
                   TKeyEdgeSerializer,
                   TValueEdgeSerializer)

        { }

        #endregion

        #endregion


        #region (protected) CheckAndFixPropertyValueType(ref Type)

        /// <summary>
        /// Checks and fixes all property value types.
        /// </summary>
        /// <param name="Type">A property value type as string.</param>
        protected override Boolean CheckAndFixPropertyValueType(ref String Type)
        {

            Type = Type.ToLower();

            if (Type == "byte" || Type == "int16" || Type == "uint16" || Type == "int32" || Type == "uint32")
                Type = "int";

            if (Type == "int64" || Type == "uint64")
                Type = "long";

            if (Type == "boolean" ||
                Type == "string" ||
                Type == "float" ||
                Type == "double" ||
                Type == "int" ||
                Type == "long")
            {
                return true;
            }

            if (IgnoreUnknownPropertyTypes)
                return false;

            throw new Exception("Unknown or invalid property value type '" + Type + "'!");

        }

        #endregion

        #region (private) SerializedPropertyTypeMap

        private String SerializedPropertyTypeMap()
        {

            if (!IncludePropertyTypes)
                return String.Empty;

            var _PropertyTypes = new StringBuilder();

            VertexPropertyTypes.ForEach(NewKeyKeyTypePair => _PropertyTypes.Append("  <key id=\"").
                                                                            Append(NewKeyKeyTypePair.Key).
                                                                            Append("\" for=\"node\" attr.name=\"").
                                                                            Append(NewKeyKeyTypePair.Value.Item1).
                                                                            Append("\" attr.type=\"").
                                                                            Append(NewKeyKeyTypePair.Value.Item2).
                                                                            AppendLine("\"/>"));

            EdgePropertyTypes.  ForEach(NewKeyKeyTypePair => _PropertyTypes.Append("  <key id=\"").
                                                                            Append(NewKeyKeyTypePair.Key).
                                                                            Append("\" for=\"edge\" attr.name=\"").
                                                                            Append(NewKeyKeyTypePair.Value.Item1).
                                                                            Append("\" attr.type=\"").
                                                                            Append(NewKeyKeyTypePair.Value.Item2).
                                                                            AppendLine("\"/>"));

            return _PropertyTypes.ToString().TrimEnd();

        }

        #endregion


        #region Serialize(Graph)

        /// <summary>
        /// Serialize the given graph.
        /// </summary>
        /// <param name="Graph">A graph.</param>
        public override String Serialize(IReadOnlyGenericPropertyGraph<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                                       TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                                       TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                                       TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Graph,

                                         IEnumerable<TKeyVertex>    VertexKeyFilter     = null,
                                         IEnumerable<TKeyEdge>      EdgeKeyFilter       = null,
                                         IEnumerable<TKeyMultiEdge> MultiEdgeKeyFilter  = null,
                                         IEnumerable<TKeyHyperEdge> HyperEdgeKeyFilter  = null)

        {

            var Body = new StringBuilder();
            Graph.Vertices().ForEach(Vertex => Body.AppendLine(this.Serialize(Vertex)));
            Graph.Edges()   .ForEach(Edge   => Body.AppendLine(this.Serialize(Edge)));

            return "";

        }

        #endregion

        #region SerializeProperties(Properties)

        public String SerializeProperties<TKey, TValue>(IReadOnlyProperties<TKey, TValue>  Properties,
                                                        Func<TKey,   String>               KeySerializer,
                                                        Func<TValue, String>               ValueSerializer)

            where TKey : IEquatable<TKey>, IComparable<TKey>, IComparable

        {

            var VertexPropertyList = new List<String>();
            var VertexPropertyValue = "";

            foreach (var p in Properties)
            {

                var _JSONString = p.Value as JSONString;

                if (_JSONString != null)
                    VertexPropertyValue = _JSONString.JSONString;
                else
                    VertexPropertyValue = ValueSerializer(p.Value);

                VertexPropertyList.Add(String.Concat(@"""", p.Key, @""": ", VertexPropertyValue));

            }

            return VertexPropertyList.CSVAggregate(@"""Properties"": { ", " }");

        }

        #endregion

        #region Serialize(Vertex, PropertyMapper = null, PropertyFilter = null, KeyFilter = null)

        /// <summary>
        /// Serialize the given vertex.
        /// </summary>
        /// <param name="Vertex">A property vertex.</param>
        /// <param name="PropertyMapper">A delegate to map a given KeyValuePair to another KeyValuePair.</param>
        /// <param name="PropertyFilter">A delegate to filter out some properties.</param>
        /// <param name="KeyFilter">An enumeration of property keys to be removed.</param>
        public override String Serialize(IReadOnlyGenericPropertyVertex<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                                        TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                                        TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                                        TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Vertex,

                                         KeyValueFilter<TKeyVertex, TValueVertex>  PropertyFilter  = null,
                                         IEnumerable   <TKeyVertex>                KeyFilter       = null,
                                         KeyValueMapper<TKeyVertex, TValueVertex>  PropertyMapper  = null)

        {

            var SerializedVertex  = new StringBuilder(@"{ ""AddVertex"": { ").Append(SerializeProperties(Vertex, TKeyVertexSerializer, TValueVertexSerializer));

            var SerializedEdges   = Vertex.OutEdges().Select(e => String.Concat(@"{ ""InVertex"": ",
                                                                                VertexIdSerializer(e.InVertex.Id),
                                                                                ", ",
                                                                                SerializeProperties(e, TKeyEdgeSerializer, TValueEdgeSerializer),
                                                                                " }"));

            if (SerializedEdges.Any())
                SerializedVertex.AppendCSV(@", ""OutEdges"": [ ", SerializedEdges, " ]");

            return SerializedVertex.Append("} }").ToString();

        }

        #endregion

        #region Serialize(Edge)

        /// <summary>
        /// Serialize the given edge.
        /// </summary>
        /// <param name="Edge">A edge.</param>
        public override String Serialize(IReadOnlyGenericPropertyEdge<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                                      TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                                      TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                                      TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Edge,

                                         KeyValueFilter<TKeyVertex, TValueVertex> PropertyFilter  = null,
                                         IEnumerable   <TKeyVertex>               KeyFilter       = null,
                                         KeyValueMapper<TKeyVertex, TValueVertex> PropertyMapper  = null)

        {

            return "";

        }

        #endregion

        #region Serialize(MultiEdge)

        /// <summary>
        /// Serialize the given multiedge.
        /// </summary>
        /// <param name="MultiEdge">A multiedge.</param>
        public override String Serialize(IReadOnlyGenericPropertyMultiEdge<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                                           TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                                           TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                                           TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> MultiEdge)
        {

            return "";

        }

        #endregion

        #region Serialize(HyperEdge)

        /// <summary>
        /// Serialize the given hyperedge.
        /// </summary>
        /// <param name="HyperEdge">A hyperedge.</param>
        public override String Serialize(IReadOnlyGenericPropertyHyperEdge<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                                           TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                                           TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                                           TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> HyperEdge)
        {

            return "";

        }

        #endregion



        #region ParseVertex(Graph, SerializedVertex)

        public override IReadOnlyGenericPropertyVertex<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                       TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                       TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                       TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>

            ParseVertex(IGenericPropertyGraph<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                              TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                              TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                              TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>  Graph,
                        String                                                                                                 SerializedVertex)

        {
            throw new NotImplementedException();
        }

        #endregion

        #region ParseEdge(Graph, SerializedEdge)

        public override IReadOnlyGenericPropertyEdge<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                     TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                     TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                     TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>

            ParseEdge(IGenericPropertyGraph<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                            TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                            TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                            TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>  Graph,
                      String                                                                                                 SerializedEdge)

        {
            throw new NotImplementedException();
        }

        #endregion

        #region ParseMultiEdge(Graph, SerializedMultiEdge)

        public override IReadOnlyGenericPropertyMultiEdge<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                          TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                          TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                          TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>

            ParseMultiEdge(IGenericPropertyGraph<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                 TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                 TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                 TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>  Graph,
                           String                                                                                                 SerializedMultiEdge)

        {
            throw new NotImplementedException();
        }

        #endregion

        #region ParseHyperEdge(Graph, SerializedHyperEdge)

        public override IReadOnlyGenericPropertyHyperEdge<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                          TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                          TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                          TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>

            ParseHyperEdge(IGenericPropertyGraph<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                 TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                 TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                 TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>  Graph,
                           String                                                                                                 SerializedHyperEdge)

        {
            throw new NotImplementedException();
        }

        #endregion

    }

}
