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
using System.Linq;
using System.Collections.Generic;

#endregion

namespace GEXFSharp
{

    public class Metadata : IMetadata
    {

        #region Properties

        public String    Creator      { get; set; }
        public String    Description  { get; set; }
        public DateTime? LastModified { get; set; }

        #region Keywords

        private readonly List<String> _Keywords;

        public IEnumerable<String> Keywords
        {
            get
            {
                return _Keywords;
            }
        }

        #endregion

        #endregion

        #region Constructor(s)

        #region Metadata(myCreator = null, myDescription = null, myLastModified = null, myKeywords = null))

        public Metadata(String myCreator = null, String myDescription = null, DateTime? myLastModified = null, IEnumerable<String> myKeywords = null)
        {

            Creator       = myCreator;
            Description   = myDescription;
            LastModified  = myLastModified ?? DateTime.Now;
            
            if (myKeywords.IsNotNullOrEmpty())
                _Keywords = new List<String>(myKeywords);

            else
                _Keywords = new List<String>();

        }

        #endregion

        #endregion


        #region AddKeyword(myKeyword)

        public IMetadata AddKeyword(String myKeyword)
        {

            lock (_Keywords)
            {
                _Keywords.Add(myKeyword);
            }

            return this;

        }

        #endregion

        #region AddKeywords(myKeywords)

        public IMetadata AddKeywords(IEnumerable<String> myKeywords)
        {

            lock (_Keywords)
            {
                _Keywords.AddRange(myKeywords);
            }

            return this;

        }

        #endregion

        #region RemoveKeywords(myKeywords)

        public IMetadata RemoveKeywords(IEnumerable<String> myKeywords = null)
        {

            lock (_Keywords)
            {

                if (myKeywords != null)
                    foreach (var _Keyword in myKeywords)
                        _Keywords.Remove(_Keyword);

                else
                    ClearKeywords();

            }

            return this;

        }

        #endregion

        #region ClearKeywords()

        public IMetadata ClearKeywords()
        {

            lock (_Keywords)
            {
                _Keywords.Clear();
            }

            return this;

        }

        #endregion

    }

}
