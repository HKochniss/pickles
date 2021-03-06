﻿#region License

/*
    Copyright [2011] [Jeffrey Cameron]

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

#endregion

using System.Collections.Generic;
using System.Linq;

namespace Pickles.Parser
{
    internal class TableBuilder
    {
        private readonly List<TableRow> cells;
        private readonly TableRow header;
        private bool hasHeader;

        public TableBuilder()
        {
            hasHeader = false;
            header = new TableRow();
            cells = new List<TableRow>();
        }

        public void AddRow(IEnumerable<string> cells)
        {
            if (hasHeader)
            {
                this.cells.Add(new TableRow(cells.ToArray()));
            }
            else
            {
                hasHeader = true;
                header.AddRange(cells);
            }
        }

        public Table GetResult()
        {
            if (!hasHeader) return null;

            return new Table
                       {
                           HeaderRow = header,
                           DataRows = cells
                       };
        }
    }
}