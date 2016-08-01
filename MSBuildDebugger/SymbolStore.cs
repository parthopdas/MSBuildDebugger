using System;
using System.Xml;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Text;

namespace MSBuildDebugger
{
    internal class SymbolStore
    {
        private Dictionary<string, PDB> symbolInformation;

        private static SymbolStore instance;
        internal static SymbolStore Instance
        {
            get
            {
                if (null == instance) instance = new SymbolStore();
                return instance;
            }
        }

        private SymbolStore()
        {
            symbolInformation = new Dictionary<string, PDB>(StringComparer.OrdinalIgnoreCase);
        }

        internal PDB this[string executablePath]
        {
            get
            {
                return symbolInformation[executablePath];
            }
        }

        internal PDB LoadSymbols(string executablePath)
        {
            if (!symbolInformation.ContainsKey(executablePath))
            {
                symbolInformation[executablePath] = PDB.Create(executablePath);
            }

            return symbolInformation[executablePath];
        }
    }
}
