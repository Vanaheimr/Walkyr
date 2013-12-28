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
using System.Collections.Generic;

#endregion

namespace eu.Vanaheimr.Walkyr
{

    /// <summary>
    /// An abstract string graph serializer.
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
    public abstract class AStringGraphSerializer<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                 TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                 TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                 TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>

          : AGraphSerializer<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                             TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                             TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                             TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge,
                             String>

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

        #region Data

        /// <summary>
        /// A keyid-key-valuetype dictionary for all vertices.
        /// </summary>
        protected readonly Dictionary<String, Tuple<String, String>> VertexPropertyTypes;

        /// <summary>
        /// A keyid-key-valuetype dictionary for all edges.
        /// </summary>
        protected readonly Dictionary<String, Tuple<String, String>> EdgePropertyTypes;

        /// <summary>
        /// A keyid-key-valuetype dictionary for all multiedges.
        /// </summary>
        protected readonly Dictionary<String, Tuple<String, String>> MultiEdgePropertyTypes;

        /// <summary>
        /// A keyid-key-valuetype dictionary for all hyperedges.
        /// </summary>
        protected readonly Dictionary<String, Tuple<String, String>> HyperEdgePropertyTypes;

        #endregion

        #region Constructor(s)

        #region AStringSerializer(IncludePropertyTypes = false, IgnoreUnknownPropertyTypes = false, IncludeMultiAndHyperEdges = false)

        /// <summary>
        /// Creates a new abstract string serializer.
        /// </summary>
        /// <param name="IncludePropertyTypes">Wether the property types should be included or not.</param>
        /// <param name="IgnoreUnknownPropertyTypes">Wether to ignore properties with unknown property types.</param>
        /// <param name="IncludeMultiAndHyperEdges">Wether the multi- and hyperedges should be included or not.</param>
        public AStringGraphSerializer(Boolean IncludePropertyTypes       = false,
                                      Boolean IgnoreUnknownPropertyTypes = false,
                                      Boolean IncludeMultiAndHyperEdges  = false)

            : base(IncludePropertyTypes, IgnoreUnknownPropertyTypes, IncludeMultiAndHyperEdges)

        {

            if (IncludePropertyTypes)
            {

                VertexPropertyTypes    = new Dictionary<String, Tuple<String, String>>();
                EdgePropertyTypes      = new Dictionary<String, Tuple<String, String>>();

                if (IncludeMultiAndHyperEdges)
                {
                    MultiEdgePropertyTypes = new Dictionary<String, Tuple<String, String>>();
                    HyperEdgePropertyTypes = new Dictionary<String, Tuple<String, String>>();
                }

            }

        }

        #endregion

        #endregion


        #region (abstract) CheckAndFixPropertyValueType(ref Type)

        /// <summary>
        /// Checks and fixes all property value types.
        /// </summary>
        /// <param name="Type">A property value type as string.</param>
        /// <returns>True if this property should be serialized; False otherwise.</returns>
        protected abstract Boolean CheckAndFixPropertyValueType(ref String Type);

        #endregion


        #region ObjectSerializer(_Double)

        /// <summary>
        /// Serializes the given Double.
        /// </summary>
        /// <param name="_Double">A Double.</param>
        /// <returns>The serialized Double.</returns>
        protected String ObjectSerializer(Double _Double)
        {
            return _Double.ToString().Replace(",", ".");
        }

        #endregion

        #region (override) ObjectSerializer(Object Object)

        /// <summary>
        /// Serializes the given Object.
        /// </summary>
        /// <param name="Object">An Object.</param>
        /// <returns>The serialized Object.</returns>
        protected override String ObjectSerializer(Object Object)
        {

            if (Object is Double)
                return ObjectSerializer((Double) Object);

            return "\"" + Object.ToString() + "\"";

        }

        #endregion


        #region (protected) GetOrCreateVertexPropertyKeyName(KeyValuePair, out KeyId)

        /// <summary>
        /// Get or create a new vertex keyid-key-valuetype mapping.
        /// </summary>
        /// <param name="KeyValuePair">A KeyValuePair.</param>
        /// <param name="KeyId">The KeyId to use.</param>
        /// <returns>True if this property should be serialized; False otherwise.</returns>
        protected Boolean GetOrCreateVertexPropertyKeyName(KeyValuePair<TKeyVertex, TValueVertex> KeyValuePair, out String KeyId)
        {
            return GetOrCreatePropertyKeyName(VertexPropertyTypes, KeyValuePair.Key.ToString(), KeyValuePair.Value.GetType().Name, out KeyId);
        }

        #endregion

        #region (protected) GetOrCreateEdgePropertyKeyName(KeyValuePair, out KeyId)

        /// <summary>
        /// Get or create a new edge keyid-key-valuetype mapping.
        /// </summary>
        /// <param name="KeyValuePair">A KeyValuePair.</param>
        /// <param name="KeyId">The KeyId to use.</param>
        /// <returns>True if this property should be serialized; False otherwise.</returns>
        protected Boolean GetOrCreateEdgePropertyKeyName(KeyValuePair<TKeyEdge, TValueEdge> KeyValuePair, out String KeyId)
        {
            return GetOrCreatePropertyKeyName(EdgePropertyTypes, KeyValuePair.Key.ToString(), KeyValuePair.Value.GetType().Name, out KeyId);
        }

        #endregion

        #region (protected) GetOrCreateMultiEdgePropertyKeyName(KeyValuePair, out KeyId)

        /// <summary>
        /// Get or create a new multiedge keyid-key-valuetype mapping.
        /// </summary>
        /// <param name="KeyValuePair">A KeyValuePair.</param>
        /// <param name="KeyId">The KeyId to use.</param>
        /// <returns>True if this property should be serialized; False otherwise.</returns>
        protected Boolean GetOrCreateMultiEdgePropertyKeyName(KeyValuePair<TKeyMultiEdge, TValueMultiEdge> KeyValuePair, out String KeyId)
        {
            return GetOrCreatePropertyKeyName(MultiEdgePropertyTypes, KeyValuePair.Key.ToString(), KeyValuePair.Value.GetType().Name, out KeyId);
        }

        #endregion

        #region (protected) GetOrCreateHyperEdgePropertyKeyName(KeyValuePair, out KeyId)

        /// <summary>
        /// Get or create a new hyperedge keyid-key-valuetype mapping.
        /// </summary>
        /// <param name="KeyValuePair">A KeyValuePair.</param>
        /// <param name="KeyId">The KeyId to use.</param>
        /// <returns>True if this property should be serialized; False otherwise.</returns>
        protected Boolean GetOrCreateHyperEdgePropertyKeyName(KeyValuePair<TKeyHyperEdge, TValueHyperEdge> KeyValuePair, out String KeyId)
        {
            return GetOrCreatePropertyKeyName(HyperEdgePropertyTypes, KeyValuePair.Key.ToString(), KeyValuePair.Value.GetType().Name, out KeyId);
        }

        #endregion

        #region (private) GetOrCreatePropertyKeyName(Dictionary, Key, Type, out KeyId)

        /// <summary>
        /// Get or create a new keyid-key-valuetype mapping.
        /// </summary>
        /// <param name="Dictionary">The dictionary to use.</param>
        /// <param name="Key">The property key.</param>
        /// <param name="Type">The property value type.</param>
        /// <param name="KeyId">The KeyId to use.</param>
        /// <returns>True if this property should be serialized; False otherwise.</returns>
        private Boolean GetOrCreatePropertyKeyName(Dictionary<String, Tuple<String, String>> Dictionary, String Key, String Type, out String KeyId)
        {

            if (Dictionary == null)
            {
                KeyId = Key;
                return true;
            }

            // Type may be fixed here! (e.g. "Int32" -> "int")
            if (CheckAndFixPropertyValueType(ref Type))
            {

                Tuple<String, String> KeyValueTuple;

                if (Dictionary.TryGetValue(Key, out KeyValueTuple))
                {

                    if (Type.Equals(KeyValueTuple.Item2))
                    {
                        KeyId = Key;
                        return true;
                    }

                    // key exists => create new key "key__type"
                    KeyId = Key + "__" + Type;

                    if (!Dictionary.ContainsKey(KeyId))
                        Dictionary.Add(KeyId, new Tuple<String, String>(Key, Type));

                    return true;

                }

                else
                {
                    Dictionary.Add(Key, new Tuple<String, String>(Key, Type));
                    KeyId = Key;
                    return true;
                }

            }

            else
            {
                KeyId = String.Empty;
                return false;
            }

        }

        #endregion


    }

}
