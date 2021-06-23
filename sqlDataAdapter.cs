using System;
using System.Data;
using System.Data.SqlClient;

namespace proiectulMeu
{
    internal class sqlDataAdapter
    {
        public static implicit operator sqlDataAdapter(SqlDataAdapter v)
        {
            throw new NotImplementedException();
        }

        internal void Fill(DataSet ds)
        {
            throw new NotImplementedException();
        }
    }
}