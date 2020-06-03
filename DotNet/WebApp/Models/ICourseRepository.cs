using System.Collections.Generic;

namespace WebApp.Models
{
    public interface ICourseRepository
    {
        Course GetCourse(int id);
        Course GetCourseByCurrencyName(string courseName);
        IEnumerable<Course> GetAllCourses();
        Course Add(Course course);
        Course Update(Course course);
        Course Delete(int id);
        decimal GetBuyRateByCurrencyName(string currName);
        decimal GetSellRateByCurrencyName(string currName);
        public List<string> GetUniqueCurrencies();
    }
}
