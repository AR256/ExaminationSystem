﻿using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Repositories
{
    public class InstructorRepo : IInstructorRepo
    {
        Exam_Context _context;

        public InstructorRepo(Exam_Context examContext)
        {
            _context = examContext;
        }
        public List<Instructor> GetAll()
        {
            return _context.Instructors.ToList();
        }
        public Instructor GetById(int id)
        {
            return _context.Instructors.SingleOrDefault(ins => ins.Instructor_Id == id);
        }
        public void Add(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }
        public void Update(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var instructorToDelete = _context.Instructors.SingleOrDefault(ins => ins.Instructor_Id == id);
            _context.Instructors.Remove(instructorToDelete);
            _context.SaveChanges();
        }
    }
}