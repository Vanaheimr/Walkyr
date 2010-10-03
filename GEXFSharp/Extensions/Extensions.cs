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
using System.Linq;
using System.Text;
using System.Collections.Generic;

#endregion

namespace GEXFSharp
{

    public static class Extensions
    {

        #region IsNotNullOrEmpty(this myString)

        public static Boolean IsNotNullOrEmpty(this String myString)
        {
            return myString != null && myString.Trim() != "";
        }

        #endregion

        #region IsNullOrEmpty(this myString)

        public static Boolean IsNullOrEmpty(this String myString)
        {
            return myString == null || myString.Trim() == "";
        }

        #endregion


        #region IsNotNullOrEmpty(this myEnumerableOfStrings)

        public static Boolean IsNotNullOrEmpty(this IEnumerable<String> myEnumerableOfStrings)
        {
            return myEnumerableOfStrings != null && myEnumerableOfStrings.Any();
        }

        #endregion

        #region IsNullOrEmpty(this myEnumerableOfStrings)

        public static Boolean IsNullOrEmpty(this IEnumerable<String> myEnumerableOfStrings)
        {
            return myEnumerableOfStrings == null || !myEnumerableOfStrings.Any();
        }

        #endregion

        #region ToCommaSeperatedList(this myEnumerableOfStrings)

        public static String ToCommaSeperatedList(this IEnumerable<String> myEnumerableOfStrings)
        {

            if (myEnumerableOfStrings.IsNotNullOrEmpty())
            {

                var _StringBuilder = new StringBuilder();

                foreach (var _String in myEnumerableOfStrings)
                    _StringBuilder.Append(_String).Append(", ");

                _StringBuilder.Length = _StringBuilder.Length - 2;

                return _StringBuilder.ToString();

            }

            return "";

        }

        #endregion


        #region ToSafeString(this myDateTime)

        public static String ToSafeString(this DateTime? myDateTime)
        {

            if (myDateTime != null)
                return myDateTime.Value.ToString();

            return "";

        }

        #endregion


    }

}
