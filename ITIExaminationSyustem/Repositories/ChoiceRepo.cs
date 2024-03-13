using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem.Repositories
{
    public class ChoiceRepo : IChoiceRepo
    {
        private Exam_Context _context;

        public ChoiceRepo(Exam_Context examContext)
        {
            _context = examContext;
        }
        public List<Choice> GetAll()
        {
            return _context.Choices.ToList();
        }
        public Choice GetById(int id)
        {
            return _context.Choices.SingleOrDefault(choice => choice.Choice_Id == id);
        }
        public void Add(Choice choice)
        {
            _context.Choices.Add(choice);
            _context.SaveChanges();
        }
        public void Update(Choice choice)
        {
            _context.Choices.Update(choice);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var choiceToDelete = GetById(id);
            _context.Choices.Remove(choiceToDelete);
            _context.SaveChanges();
        }
    }
}
