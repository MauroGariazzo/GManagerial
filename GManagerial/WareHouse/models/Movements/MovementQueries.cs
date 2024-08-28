using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GManagerial.WareHouse.models.Movements
{
    internal class MovementQueries
    {
        public static String GetSpecificDateQuery(string typeMovement, string year, string month, string day, string text)
        {
            string query = "SELECT * FROM WareHouse_MovementTbl WHERE 1=1";

            if (!string.IsNullOrEmpty(typeMovement))
            {
                query += " AND Type = @TypeMovement";
            }

            if (!string.IsNullOrEmpty(year))
            {
                query += " AND YEAR(Date) = @Year";
            }

            if (!string.IsNullOrEmpty(month))
            {
                query += " AND MONTH(Date) = @Month";
            }

            if (!string.IsNullOrEmpty(day))
            {
                query += " AND DAY(Date) = @Day";
            }

            if (!string.IsNullOrEmpty(text))
            {
                query += " AND Type LIKE @Text";
                query += " OR Causal LIKE @Text";
            }

            return query;
        }

        public static String GetIntervalDateQuery(string typeMovement, string startDate, string endDate, string text)
        {
            string query = "SELECT * FROM WareHouse_MovementTbl WHERE 1=1";

            if (!string.IsNullOrEmpty(typeMovement))
            {
                query += " AND Type = @TypeMovement";
            }

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                query += " AND Date BETWEEN @StartDate AND @EndDate";
            }

            if (!string.IsNullOrEmpty(text))
            {
                query += " AND Type LIKE @Text";
                query += " OR Causal LIKE @Text";
            }
            return query;
        }
    }
}
