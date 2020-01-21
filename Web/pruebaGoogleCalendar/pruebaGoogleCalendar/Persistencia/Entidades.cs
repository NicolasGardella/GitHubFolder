using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace pruebaGoogleCalendar.Persistencia
{
    public class Entidades
    {
        public String GetString(System.Data.DataRow row, string field)
        {
            try
            {
                return row.IsNull(field) ? null : Convert.ToString(row[field]).Trim();
            }
            catch (ArgumentException ex)
            {
                return null;
            }
        }
        public string GetStr(System.Data.DataRow row, string field)
        {
            try
            {
                try
                {
                    if (row.Table.Columns[field].DataType == typeof(System.DateTime))
                    {
                        return Convert.ToDateTime(row[field]).ToString("dd/MM/yyyy HH:mm:ss.fff");

                    }

                }
                catch (Exception)
                {

                }
                string s = row.IsNull(field) ? null : Convert.ToString(row[field]).Trim();
                s = Regex.Replace(s, @"\p{C}+", string.Empty);
                return s;
            }
            catch (ArgumentException ex)
            {
                return null;
            }
        }
        public String GetStringJSON(System.Data.DataRow row, string field)
        {
            try
            {
                // ret.Colores = ret.Colores
                //ret.Colores = ret.Colores
                if (row.IsNull(field))
                {
                    return null;
                }
                else
                {
                    string j = Convert.ToString(row[field]).Trim();
                    j = j.Replace("\n", "\\n");
                    j = j.Replace("\r", "\\r");
                    return j;
                }


            }
            catch (ArgumentException ex)
            {
                return null;
            }
        }


        public int GetInt(System.Data.DataRow row, string field)
        {
            try
            {
                return row.IsNull(field) ? 0 : (int)row[field];
            }
            catch
            {

                return Convert.ToInt32(row[field]);
            }

        }
        public int? GetIntOrNull(System.Data.DataRow row, string field)
        {
            try
            {
                return row.IsNull(field) ? null : (int?)row[field];
            }
            catch
            {

                return Convert.ToInt32(row[field]);
            }

        }
        public float GetFloat(System.Data.DataRow row, string field)
        {
            try
            {
                return row.IsNull(field) ? 0 : (float)row[field];
            }
            catch
            {

                return row.IsNull(field) ? 0 : Convert.ToInt64(row[field]);
            }

        }
        public long GetLong(System.Data.DataRow row, string field)
        {
            try
            {
                return row.IsNull(field) ? 0 : (long)row[field];
            }
            catch (Exception)
            {
                return row.IsNull(field) ? 0 : Convert.ToInt64(row[field]);


            }

        }

        public double Getdbl(System.Data.DataRow row, string field)
        {
            return row.IsNull(field) ? 0 : (double)row[field];
        }

        public long GetLng(System.Data.DataRow row, string field)
        {
            return row.IsNull(field) ? 0 : (long)row[field];
        }
        public long Getint64(System.Data.DataRow row, string field)
        {
            return row.IsNull(field) ? 0 : Convert.ToInt64(row[field]);
        }

        public decimal GetDcm(System.Data.DataRow row, string field)
        {
            return row.IsNull(field) ? 0 : (decimal)row[field];
        }


        public DateTime? GetDateTimeNull(System.Data.DataRow row, string field)
        {
            if (row.IsNull(field))
            {
                return null;
            }
            return (DateTime)row[field];
        }
        public DateTime? GetDateTimeNull2(System.Data.DataRow row, string field)
        {
            DateTime d = new DateTime(1900, 01, 01, 00, 00, 00);
            if (row.IsNull(field))
            {
                return null;
            }
            if (d == (DateTime)row[field])
            {
                return null;
            }
            return (DateTime)row[field];
        }

        public DateTime GetDateTime(System.Data.DataRow row, string field)
        {
            if (row.IsNull(field))
            {
                return new DateTime();
            }
            return (DateTime)row[field];
        }

        public bool ValorBool(System.Data.DataRow row, string field)
        {
            if (row.IsNull(field))
            {
                return false;
            }

            return true;
        }

        public bool GetBool(System.Data.DataRow row, string field)
        {
            try
            {
                return row.IsNull(field) ? false : (bool)row[field];
            }
            catch (ArgumentException ex)
            {
                return false;
            }
        }

    }
}