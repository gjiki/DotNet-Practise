using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class SqlCourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public SqlCourseRepository(AppDbContext context)
        {
            this._context = context;
        }

        public Course Add(Course course)
        {
            Course curr = _context.Courses.FirstOrDefault(m => m.CurrencyName == course.CurrencyName);
            course.Date = DateTime.Now;
            if (curr == null)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
            } else
            {
                course.Date = DateTime.Now;
                this.Update(course);
            }
            return course;
        }

        public Course Delete(int id)
        {
            Course curr = _context.Courses.FirstOrDefault(m => m.ID == id);
            if (curr != null)
            {
                _context.Courses.Remove(curr);
                _context.SaveChanges();
            }
            return curr;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses;
        }

        public Course GetCourse(int id)
        {
            return _context.Courses.FirstOrDefault(m => m.ID == id);
        }

        public Course GetCourseByCurrencyName(string currencyName)
        {
            return _context.Courses.FirstOrDefault(m => m.CurrencyName == currencyName);
        }

        public decimal GetBuyRateByCurrencyName(string currName)
        {
            Course curr = _context.Courses.FirstOrDefault(x => x.CurrencyName == currName);
            if (curr != null) return curr.Buy;
            return (decimal)0.0;
        }

        public decimal GetSellRateByCurrencyName(string currName)
        {
            Course curr = _context.Courses.FirstOrDefault(x => x.CurrencyName == currName);
            if (curr != null) return curr.Sell;
            return (decimal)0.0;
        }

        public Course Update(Course course)
        {
            course.Date = DateTime.Now;
            var curr = _context.Courses.Attach(course);
            curr.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return course;
        }

        public List<string> GetUniqueCurrencies()
        {
            HashSet<string> st = new HashSet<string>();
            foreach (var item in _context.Courses)
            {
                st.Add(item.CurrencyName);
            }
            return st.ToList();
        }
    }
}
