using AMCDatabase;
using System;
using System.Collections.Generic;

namespace UpdateHistoryTestFlags
{
	internal class HistoryTable : PartsTable
	{
		public HistoryTable(string sKeyValue, string sVersion, bool bTest = false) : base(sKeyValue, sVersion, bTest)
		{
		}

		public override void AddColums()
		{
			this._ColumnNames.Add("PartNumber");
			this._ColumnNames.Add("ictreq");
			this._ColumnNames.Add("regtest");
			this._ColumnNames.Add("regburn");
			this._ColumnNames.Add("mantest");
			this._ColumnNames.Add("manburn");
			this._ColumnNames.Add("testprog");
			this._ColumnNames.Add("m_regtest");
			this._ColumnNames.Add("m_regburn");
			this._ColumnNames.Add("m_mantest");
			this._ColumnNames.Add("m_manburn");
			this._ColumnNames.Add("m_testprog");
		}
	}
}