using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using MedeniyetTur.Models;

namespace MedeniyetTur.Utils
{
    public class SqlDbHelper
    {
        private readonly MySqlConnection _conn;
        private string _connectionString = "Server=localhost;Database=medeniyettur;Uid=root;Pwd=.916814.;";

        public SqlDbHelper()
        {

            _conn = new MySqlConnection(_connectionString);
        }

        public Tur GetTur(int id)
        {
            var sql = "SELECT * FROM Tur";
            var result = _conn.Query<Tur>(sql).ToList();
            var value = result.Find(x => x.Id == id);
            return value;
        }

        public List<Tur> GetTurs()
        {
            var sql = "SELECT * FROM Tur";
            var result = _conn.Query<Tur>(sql).ToList();
            return result;
        }
        public int AddTur(Tur tur)
        {
            string sql = "INSERT INTO tur (name, price, date, description, image) Values (@Name, @Price, @Date, @Description, @Image);";
            var result = _conn.Execute(sql, tur);
            return result;
        }
        public int UpdateTur(Tur tur)
        {
            string sql = "UPDATE tur Set id=@Id, price=@Price, date=@Date, description=@Description, image=@Image WHERE id=@Id";
            var result = _conn.Execute(sql, tur);
            return result;
        }
        public int DeleteTur(int id)
        {
            string sql = "DELETE FROM tur WHERE id = @Id;";
            var result = _conn.Execute(sql, new { Id = id });
            return result;
        }

        public int AddUser(User user)
        {
            string sql = "INSERT INTO user (name, surname, birthDate, email, phoneNumber, tc) Values (@Name, @Surname, @BirthDate, @Email, @PhoneNumber, @Tc);";
            var result = _conn.Execute(sql, user);
            return result;
        }
    }
}
