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

#endregion

namespace GEXFSharp
{

    public static class IMetadataExtensions
    {


        #region HasDescription(this myIMetadata)

        public static Boolean HasDescription(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            return myIMetadata.Description.IsNotNullOrEmpty();

        }

        #endregion

        #region ClearDescription(this myIMetadata)

        public static IMetadata ClearDescription(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            myIMetadata.Description = null;

            return myIMetadata;

        }

        #endregion

        #region GetDescription(this myIMetadata)

        public static String GetDescription(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            return myIMetadata.Description;

        }

        #endregion

        #region SetDescription(this myIMetadata, myDescription)

        public static IMetadata SetDescription(this IMetadata myIMetadata, String myDescription)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            if (myDescription.IsNullOrEmpty())
                throw new ArgumentNullException("myDescription must not be null!");

            myIMetadata.Description = myDescription;

            return myIMetadata;

        }

        #endregion


        #region HasCreator(this myIMetadata)

        public static Boolean HasCreator(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            return myIMetadata.Creator.IsNotNullOrEmpty();

        }

        #endregion

        #region ClearCreator(this myIMetadata)

        public static IMetadata ClearCreator(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            myIMetadata.Creator = null;

            return myIMetadata;

        }

        #endregion

        #region GetCreator(this myIMetadata)

        public static String GetCreator(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            return myIMetadata.Creator;

        }

        #endregion

        #region SetCreator(this myIMetadata, myCreator)

        public static IMetadata SetCreator(this IMetadata myIMetadata, String myCreator)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            if (myCreator.IsNullOrEmpty())
                throw new ArgumentNullException("myCreator must not be null!");

            myIMetadata.Creator = myCreator;

            return myIMetadata;

        }

        #endregion


        #region HasLastModified(this myIMetadata)

        public static Boolean HasLastModified(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            return myIMetadata.LastModified != null;

        }

        #endregion

        #region ClearLastModified(this myIMetadata)

        public static IMetadata ClearLastModified(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            myIMetadata.LastModified = null;
            
            return myIMetadata;

        }

        #endregion

        #region GetLastModified(this myIMetadata)

        public static DateTime? GetLastModified(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            return myIMetadata.LastModified;

        }

        #endregion

        #region SetLastModified(this myIMetadata, myLastModified)

        public static IMetadata SetLastModified(this IMetadata myIMetadata, DateTime? myLastModified)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            if (myLastModified == null)
                throw new ArgumentNullException("myLastModified must not be null!");

            myIMetadata.LastModified = myLastModified;

            return myIMetadata;

        }

        #endregion


        #region HasKeywords(this myIMetadata)

        public static Boolean HasKeywords(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            return myIMetadata.Keywords.IsNotNullOrEmpty();

        }

        #endregion


        #region ClearMetadata(this myIMetadata)

        public static IMetadata ClearMetadata(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            myIMetadata.Creator      = null;
            myIMetadata.Description  = null;
            myIMetadata.LastModified = null;

            myIMetadata.ClearKeywords();

            return myIMetadata;

        }

        #endregion


        #region IsEmpty(this myIMetadata)

        public static Boolean IsEmpty(this IMetadata myIMetadata)
        {

            if (myIMetadata == null)
                throw new ArgumentNullException("myIMetadata must not be null!");

            return (!myIMetadata.Keywords.IsNotNullOrEmpty() &&
                    !myIMetadata.HasCreator() &&
                    !myIMetadata.HasDescription() &&
                    !myIMetadata.HasLastModified());

        }

        #endregion


    }

}
