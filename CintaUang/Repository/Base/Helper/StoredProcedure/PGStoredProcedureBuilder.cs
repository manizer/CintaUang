using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;

namespace Repository.Base.Helper.StoredProcedure
{
    public class PGStoredProcedureBuilder : StoredProcedureBuilder
    {
        public override IStoredProcedureBuilder AddParam(string Key, object Value)
        {
            Params.Add(new KeyValuePair<string, object>(Key, Value));
            return this;
        }

        public override StoredProcedure SP()
        {
            string QueryParamsTemplate = "";
            for (int i = 0; i < Params.Count; i++)
            {
                QueryParamsTemplate += "{" + i + "}";
                if (i != Params.Count - 1) QueryParamsTemplate += ", ";
            }
            string QueryStr = $"SELECT * FROM {SPName} ({QueryParamsTemplate})";
            StoredProcedure sp = new StoredProcedure
            {
                SP = QueryStr,
                args = Params.Select(x => x.Value).ToArray()
            };
            Dispose();
            return sp;
        }

        public override IStoredProcedureBuilder WithSPName(string StoredProcedureName)
        {
            SPName = StoredProcedureName;
            return this;
        }
    }
}
