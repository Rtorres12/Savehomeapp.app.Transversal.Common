using System;
using Savehomeapp.app.Domain.Entity;
using Savehomeapp.app.Domain.Core;
using Savehomeapp.app.Infrastructure.Interface;
using Savehomeapp.app.Domain.Interface;
using System.Collections.Generic;

namespace Savehomeapp.app.Domain.Core
{
    public class CoursesDomain: ICoursesDomain
    {
        private readonly ICoursesRepository _courseRepository;
        public CoursesDomain(ICoursesRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public int Insert(Courses course)
        {
            return _courseRepository.Insert(course);
        }

        public IEnumerable<Courses> GetList()
        {
        return _courseRepository.GetList();
        }
        public IEnumerable<Courses> GetByIdCategorie(int categorieId) 
        {
            return _courseRepository.GetByIdCategorie(categorieId);
        }

        public bool Delete(Courses courses)
        {
            return _courseRepository.Delete(courses);
        }
        public bool Update(Courses courses)
        {
            return _courseRepository.Update(courses);
        }
    }
}
