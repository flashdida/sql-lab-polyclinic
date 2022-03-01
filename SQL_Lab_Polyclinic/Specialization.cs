using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Lab_Polyclinic {
  public class Specialization {
    public int Id { get; set; }
    public string Name { get; set; }
    public static List<Specialization> GetDeletedSpecializations() {
      var list = new List<Specialization>();
      using (var conn = new SqlConnection(Properties.Resources.ConnectionString)) {
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"SELECT * FROM Specializations 
                            WHERE IsDeleted<>0";
        var reader = cmd.ExecuteReader();
        while (reader.Read())
          list.Add(new Specialization() { Id = reader.GetInt32(0), Name = reader.GetString(1) });
      }
      return list;
    }
    public static List<Specialization> GetSpecializations() {
      var list = new List<Specialization>();
      using (var conn = new SqlConnection(Properties.Resources.ConnectionString)) {
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"SELECT * FROM Specializations 
                            WHERE IsDeleted<>1";
        var reader = cmd.ExecuteReader();
        while (reader.Read())
          list.Add(new Specialization() { Id = reader.GetInt32(0), Name = reader.GetString(1) });
      }
      return list;
    }
        public static List<Specialization> GetSpecializations(SqlConnection con, SqlTransaction trans)
        {
            var list = new List<Specialization>();
            
            
                
                var cmd = con.CreateCommand();
            cmd.Transaction = trans;
                cmd.CommandText = @"SELECT * FROM Specializations 
                            WHERE IsDeleted<>1";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(new Specialization() { Id = reader.GetInt32(0), Name = reader.GetString(1) });
            
            return list;
        }
    }
}
