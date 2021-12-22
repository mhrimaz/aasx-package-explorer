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
    /// This class makes an approach to translate a Submodel into respective AML roles and attributes
    /// </summary>
    public class AmlExportStruct : AmlExportBase
    {
        public static bool ExportTo(AdminShellPackageEnv package, string amlfn, 
            AdminShell.Submodel submodel = null)
        {
            // start
            if (package == null || amlfn == null || package.AasEnv == null)
                return false;

            // create main doc
            var doc = CAEXDocument.New_CAEXDocument(CAEXDocument.CAEXSchema.CAEX2_15);

            // create hierarchies
            var insthier = doc.CAEXFile.InstanceHierarchy.Append(AmlConst.Names.RootInstHierarchy);

            // DEMO code
            var smIE = AppendIeNameAndRole(
                insthier.InternalElement, name: "DEMO" + submodel?.idShort, altName: "SM", role: AmlConst.Roles.AAS);

            // save and return
            doc.SaveToFile(amlfn, prettyPrint: true);
            return true;
        }
    }
}
