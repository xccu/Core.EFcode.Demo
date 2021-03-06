using Microsoft.EntityFrameworkCore;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly MySqlContext _context;

        public CourseRepository(MySqlContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public IQueryable<Course> getByUser(int userId)
        {
            var course = _context.Course
                .Join(_context.UserCourse, c => c.id, uc => uc.courseId, (c, uc) => new { c, uc })
                .Join(_context.User, c => c.uc.userId, u => u.id, (uc, u) => new { uc, u })
                .Where(t => t.u.id == userId).Select(t => t.uc.c) ;

            return course;
        }
    }
}
