using Equinox.Questions.Entities.Model;
using Equinox.Questions.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Equinox.Common.Connection.Interface;
using Equinox.Common.Connection.Service;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.VisualBasic;

namespace Equinox.Questions.Services.CRUD.Questions
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IDatabaseConnection _databaseConnection;
        private SqlConnection _conn;
        public QuestionRepository()
        {
            _databaseConnection = new DatabaseConnection();
            _conn = _databaseConnection.GetSqlConnection();
        }
        public void Add(Question question)
        {
            string Sql = "INSERT INTO Questions () VALUES ()";

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    _conn.Open();
                }
                catch(SqlException exc)
                {
                    throw new Exception(exc.Message);
                }
                catch(Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }
            SqlCommand cmd = _conn.CreateCommand();
            cmd.CommandText = Sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@OrderNo",question.OrderNo);
            // TODO: Add more parameters ..

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(SqlException exc)
            {
                throw new Exception(exc.Message);
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }

            if (_conn.State == System.Data.ConnectionState.Open)
                _conn.Dispose();
        }

        public async Task AddAsync(Question question)
        {
            string Sql = "INSERT INTO Questions () VALUES ()";

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    _conn.Open();
                }
                catch (SqlException exc)
                {
                    throw new Exception(exc.Message);
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }
            SqlCommand cmd = _conn.CreateCommand();
            cmd.CommandText = Sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@OrderNo", question.OrderNo);
            // TODO: Add more parameters ..

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            catch (SqlException exc)
            {
                throw new Exception(exc.Message);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            if (_conn.State == System.Data.ConnectionState.Open)
                _conn.Dispose();
        }

        public void AddRange(Question[] questions)
        {
            throw new NotImplementedException();
        }

        public void Delete(Question question)
        {
            string Sql = "UPDATE Questions SET IsDeleted = 1 WHERE Id = @OrderNo";
            if (_conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    _conn.Open();
                }
                catch(SqlException exc)
                {
                    throw new Exception(exc.Message);
                }
            }

            SqlCommand cmd = _conn.CreateCommand();
            cmd.CommandText = Sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@OrderNo", question.OrderNo);
            try 
            {
                cmd.ExecuteNonQuery();
            }
            catch(SqlException exc)
            {
                throw new Exception(exc.Message);
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }

            if (_conn.State == System.Data.ConnectionState.Open)
                _conn.Dispose();
        }

        public async Task DeleteAsync(int orderNo)
        {
            string Sql = "UPDATE Questions SET IsDeleted = 1 WHERE Id = @OrderNo";
            if (_conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    _conn.Open();
                }
                catch (SqlException exc)
                {
                    throw new Exception(exc.Message);
                }
            }

            SqlCommand cmd = _conn.CreateCommand();
            cmd.CommandText = Sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@OrderNo", orderNo);
            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            catch (SqlException exc)
            {
                throw new Exception(exc.Message);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            if (_conn.State == System.Data.ConnectionState.Open)
                _conn.Dispose();
        }

        public Question Get(int id)
        {
            string Sql = "SELECT Id,OrderNo,Text,QuestionScope,QuestionGrade,MulitAnswer,IsDeleted  FROM Questions WHERE OrderNo=@OrderNo AND IsDeleted=0";
            if (_conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    _conn.Open();
                }
                catch (SqlException exc)
                {
                    throw new Exception(exc.Message);
                }
            }

            SqlDataReader dr = null;
            SqlCommand cmd = _conn.CreateCommand();
            cmd.CommandText = Sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@OrderNo", id);
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (SqlException exc)
            {
                throw new Exception(exc.Message);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            var question = new Question();
            var questions = new List<Question>();
            if (!dr.HasRows)
                return question;
            while (dr.Read())
            {
                questions.Add(
                    new Question
                    {
                        OrderNo = int.Parse(dr["OrderNo"].ToString()),
                        Text = dr["Text"].ToString(),
                        QuestionScope = (Scope)int.Parse(dr["QuestionScope"].ToString()),
                        QuestionGrade = (Grade)int.Parse(dr["QuestionGrade"].ToString()),
                        MultiAnswer = Convert.ToBoolean(dr["MultiAnswer"].ToString()),
                        IsDeleted = Convert.ToBoolean(dr["IsDeleted"].ToString())
                    });
            }
            question = questions.FirstOrDefault();

            // TODO: Get Answers and Explanations for selected Question

            var answers = GetAnswers(id);

            if (answers != null)
                question.Answers = answers;

            var explanation = GetExplanation(id);
            if (explanation != null)
                question.Explanation = explanation;


            return question;
        }

        private List<Answer> GetAnswers(int questionId)
        {
            var answers = new List<Answer>();
            string Sql = "SELECT Id, OrderNo,QuestionId,Text,IsCorrect FROM ANSWERS WHERE QuestionId = @Id";
            if (_conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    _conn.Open();
                }
                catch (SqlException exc)
                {
                    throw new Exception(exc.Message);
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }
            SqlCommand cmd = _conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = Sql;
            SqlDataReader dr = null;
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (SqlException exc)
            {
                throw new Exception(exc.Message);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    answers.Add(
                        new Answer
                        {
                            Id = new Guid(dr["Id"].ToString()),
                            QuestionId = int.Parse(dr["QuestionId"].ToString()),
                            OrderNo = int.Parse(dr["OrderNo"].ToString()),
                            Text = dr["Text"].ToString(),
                            IsCorrect = Convert.ToBoolean(dr["IsCorrect"].ToString())
                        });
                }
            }
            return answers;
        }

        private Explanation GetExplanation(int questionId)
        {
            string Sql = "SELECT Id, QuestionId, Text, LastModified FROM Explanations WHERE QuestionId = @QuestionId";
            if (_conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    _conn.Open();
                }
                catch (SqlException exc)
                {
                    throw new Exception(exc.Message);
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }

            SqlCommand cmd = _conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = Sql;
            cmd.Parameters.AddWithValue("@QuestionId", questionId);
            SqlDataReader dr = null;
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (SqlException exc)
            {
                throw new Exception(exc.Message);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            var explanations = new List<Explanation>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    explanations.Add(
                        new Explanation
                        {
                            Id = new Guid(dr["Id"].ToString()),
                            QuestionId = questionId,
                            Text = dr["Text"].ToString()
                        }) ;
                }
            }
            return explanations.FirstOrDefault();
        }

        public ICollection<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Next()
        {
            throw new NotImplementedException();
        }

        public void Update(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
