/*
Copyright (c) 2018-2021 Festo AG & Co. KG <https://www.festo.com/net/de_de/Forms/web/contact_international>
Author: Michael Hoffmeister

This source code is licensed under the Apache License 2.0 (see LICENSE.txt).

This source code may use other Open Source software components (see LICENSE.txt).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AasxIntegrationBase;
using AdminShellNS;
using Aml.Engine.AmlObjects;
using Aml.Engine.CAEX;

namespace AasxAmlImExport
{
    /// <summary>
    /// This class provides export functionality to AutomationML.
    /// This class follows the mapping between AAS structural elements and AML defined by the
    /// AAS/AML working group.
    /// </summary>
    public class AmlExportBase
    {
        /// <summary>
        /// Provides some help to add an internal element
        /// </summary>
        protected static InternalElementType AppendIeNameAndRole(
            InternalElementSequence ieseq, string name, string altName = "Unknown", string role = null)
        {
            if (ieseq == null)
                return null;
            var ie = ieseq.Append(
                name != null && name.Trim() != "" ? name : altName + " " + Guid.NewGuid().ToString());
            if (role != null)
            {
                var rr = ie.RoleRequirements.Append();
                rr.RefBaseRoleClassPath = role;
            }
            return ie;
        }

        /// <summary>
        /// Provides some help to add an attribute
        /// </summary>
        protected static AttributeType AppendAttributeNameAndRole(
            AttributeSequence aseq, string name, string role = null, string val = null,
            string attributeDataType = null)
        {
            if (aseq == null)
                return null;
            var a = aseq.Append(name);
            if (role != null)
            {
                var rf = a.RefSemantic.Append();
                rf.CorrespondingAttributePath = role;
            }
            if (val != null)
            {
                a.Value = val;
            }
            if (attributeDataType != null)
            {
                a.AttributeDataType = attributeDataType;
            }

            return a;
        }

    }
}
