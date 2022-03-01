using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Lab_Polyclinic {
  public class dbManager {
    //static string _connectionString = @"Data Source=LAPTOP-MO4BFTF8\SQLEXPRESS01;Initial Catalog=PolyclinicDatabase;Integrated Security=true;MultipleActiveResultSets=true;";
    static string _connectionString = @"Data Source=DESKTOP-RPLK01E\SQLEXPRESS;Initial Catalog=PolyclinicDatabase;Integrated Security=true;MultipleActiveResultSets=true;";
    SqlConnection _conn;
    public DataTable GetData(string sql) {
      var dt = new DataTable();
      try {
        _conn.Open();
        var cmd = _conn.CreateCommand();
        cmd.CommandText = sql;
        var adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);
      } catch {

      } finally {
        _conn.Close();
      }
      return dt;
    }
    public bool UpdateAppointment(Appointment app, out string res) {
      res = "";
      try {
        _conn.Open();
        var cmd = _conn.CreateCommand();
        cmd.CommandText = "Update Appointments set Doctor=@doc,Patient=@pat,Disease= @dis,[Date]=@date where Id=@id";
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@doc", app.Doctor);
        cmd.Parameters.AddWithValue("@pat", app.Patient);
        cmd.Parameters.AddWithValue("@dis", app.Disease);
        cmd.Parameters.AddWithValue("@date", app.Date);
        cmd.Parameters.AddWithValue("@id", app.Id);
        cmd.ExecuteNonQuery();
      } catch (Exception ex) {
        res = ex.Message;
        return false;
      } finally {
        _conn.Close();
      }
      res = "Запись была изменена";
      return true;
    }
    public bool DeleteAppointment(int id, out string res) {
      try {
        _conn.Open();
        var cmd = _conn.CreateCommand();
        cmd.CommandText = "delete from Appointments where Id=@id";
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();

      } catch (Exception ex) {
        res = ex.Message;
        _conn.Close();
        return false;
      } finally {
        _conn.Close();
      }
      res = "запись была удалена";
      return true;
    }
    public string GetInfo(int app) {
      string result = "";
      try {
        _conn.Open();
        var cmd = _conn.CreateCommand();
        string doctor = "";
        string patient = "";
        cmd.CommandText = $"select FullName from doctors where Id = (select a.Doctor from Appointments a where a.Id={app})";
        doctor = ((string)cmd.ExecuteScalar()).Split(' ')[1];
        cmd.CommandText = $"select FullName from Patients where Id = (select a.Patient from Appointments a where a.Id={app})";
        patient = ((string)cmd.ExecuteScalar()).Split(' ')[1];
        result = string.Format("{0}\t{1}", doctor, patient);
      } catch {
      } finally {
        _conn.Close();

      }
      return result;
    }
    public bool InsertAppointment(Appointment app, out string res) {
      res = "";
      try {
        _conn.Open();
        var cmd = _conn.CreateCommand();
        cmd.CommandText = "insert into Appointments values (@doc, @pat, @dis, @date)";
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@doc", app.Doctor);
        cmd.Parameters.AddWithValue("@pat", app.Patient);
        cmd.Parameters.AddWithValue("@dis", app.Disease);
        cmd.Parameters.AddWithValue("@date", app.Date);
        cmd.ExecuteNonQuery();
      } catch (Exception ex) {
        res = ex.Message;
        _conn.Close();
        return false;
      } finally {
        _conn.Close();
      }
      res = "Запись была добавлена";
      return true;
    }
    public static List<Appointment> GetAppointments() {
      var list = new List<Appointment>();
      using (var conn = new SqlConnection(_connectionString)) {
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"select a.Id, a.Doctor, a.Patient, 
                            a.Disease, a.[Date], d.FullName,
                            p.FullName
                            from appointments a 
                            join doctors d on a.Doctor=d.Id 
                            join patients p on p.Id=a.Patient 
                            join Diseases di on di.Id=a.Disease
                            where d.Specialization not in 
                            (select Id from specializations 
                            where IsDeleted=1)";
        using (var reader = cmd.ExecuteReader()) {
          while (reader.Read()) {
            string doc = reader.GetString(5).Split(' ')[1];
            string pat = reader.GetString(6).Split(' ')[1];
            list.Add(new Appointment() {
              Id = reader.GetInt32(0),
              Doctor = reader.GetInt32(1),
              Patient = reader.GetInt32(2),
              Disease = reader.GetInt32(3),
              Date = reader.GetDateTime(4),
              Representation = doc + "\t\t" + pat + "\t" + reader.GetDateTime(4).ToShortDateString()
            });
          }


        }
      }
      return list;
    }
    public dbManager() {
      EnsureCreated();
      _conn = new SqlConnection(_connectionString);
    }
    void EnsureCreated() {
      bool dbExists = false;
      using (var conn = new SqlConnection
        (_connectionString.Replace("PolyclinicDatabase", "master"))) {
        conn.Open();
        object o = new SqlCommand
          (@"select iif(exists(select * from sys.databases
             where [name] = 'PolyclinicDatabase'),1,0);", conn).
             ExecuteScalar();
        dbExists = Convert.ToBoolean(o);
        if (!dbExists)
          new SqlCommand("create database PolyclinicDatabase",
            conn).ExecuteNonQuery();
      }
      if (!dbExists) {
        using (var conn = new SqlConnection
        (_connectionString)) {
          conn.Open();
          var cmds = @"create table Patients(
	Id int primary key identity,
	Fullname nvarchar(50),
	Birthday datetime,
	Phone nvarchar(max)
);
go
set dateformat dmy;
go
insert into Patients
values('Адам Смолл','19/02/1990','09(105)089-48-37'),
('Джошуа Лонг','28/11/2019','7(626)708-27-91'),
('Уинфрид Ли','14/10/1999','3(339)448-43-78'),
('Дэвид Стаффорд','20/11/1988','12(5728)721-67-43');
go
create table Specializations(
	Id int primary key identity,
	[Name] nvarchar(30),
	IsDeleted bit
);
go
insert into Specializations 
values('терапевт',0),('педиатр',0),
('кардиолог',0),('гематолог',0),('инфекционист',0);
go
create table DiseaseClassifications(
	Id int primary key identity,
	[Name] nvarchar(50)
);
go
insert into DiseaseClassifications
values('заразные'),('незаразные')
go
create table Diseases(
	Id int primary key identity,
	[Name] nvarchar(50),
	Class int foreign key(Class) 
	references DiseaseClassifications(Id)
);
go
insert into Diseases
values ('грипп',(select Id from DiseaseClassifications 
where [Name] = 'заразные')),
('герпес',(select Id from DiseaseClassifications 
where [Name] = 'заразные')),
('чума',(select Id from DiseaseClassifications 
where [Name] = 'заразные')),
('туберкулез',(select Id from DiseaseClassifications 
where [Name] = 'заразные')),
('диабет',(select Id from DiseaseClassifications 
where [Name] = 'незаразные')),('рак',
(select Id from DiseaseClassifications 
where [Name] = 'незаразные')),
('порок сердца',(select Id from DiseaseClassifications 
where [Name] = 'незаразные'))
go
create table Doctors(
	Id int primary key identity,
	Fullname nvarchar(50),
	Specialization int foreign key(Specialization)
	references Specializations(Id),
	HiringDate datetime,
	RoomNumber int
);
go
insert into Doctors
values ('Роберт Стивенс',1,getdate(),68),
('Джейкоб Сноу',1,'26/09/2015',1),
('Роджер Парк',4,'16/12/2011',5),
('Кеннет Фармер',5,'26/09/1985',140),
('Уильям Хьюстон',2,'17/10/1997',126),
('Малколм Шарп',1,'03/02/2017',145),
('Стивен Чемберс',5,'01/07/2014',130),
('Бриттон Маккарти',3,'29/06/2015',116)
go
create table Appointments(
	Id int primary key identity,
	Doctor int foreign key(Doctor) references Doctors(Id),
	Patient int foreign key(Patient) references Patients(Id),
	[Disease] int foreign key(Disease) references Diseases(Id),
	[Date] date,
);
go
insert into Appointments
values(1,2,4,'19/01/1986 15:44:42'),
(5,4,3,'22/08/2008 15:05:02'),
(3,4,3,'11/09/2010 03:37:35'),
(8,2,6,'21/10/1998 00:48:29'),
(4,1,2,'09/10/1999 08:57:26'),
(2,4,1,'11/06/1992 08:03:45'),
(2,1,3,'18/08/2017 14:32:05'),
(3,2,6,'17/05/1993 12:12:49'),
(7,4,2,'17/05/1993 12:12:49'),
(3,2,5,'17/05/1993 12:12:49');".Split(new string[] { "go" },
StringSplitOptions.None);
          foreach (string c in cmds)
            new SqlCommand(c, conn).ExecuteNonQuery();
        }
      }
    }
  }
}
