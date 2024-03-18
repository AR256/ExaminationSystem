using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Exam_Context>(a =>
            {
                a.UseSqlServer(builder.Configuration.GetConnectionString("con1"));
            });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                options =>
                {
                    options.LoginPath= "/Account/Login";
                }
                );
            builder.Services.AddScoped<IAdminRepo, AdminRepo>();
            builder.Services.AddScoped<IBranchRepo, BranchRepo>();
            builder.Services.AddScoped<IChoiceRepo, ChoiceRepo>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IDeptInstructorRepo, DeptInstructorRepo>();
            builder.Services.AddScoped<IExamQuestionRepo, ExamQuestionRepo>();
            builder.Services.AddScoped<IExamRepo, ExamRepo>();
            builder.Services.AddScoped<IInstructorRepo, InstructorRepo>();
            builder.Services.AddScoped<IMainDeptRepo, MainDeptRepo>();
            builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
            builder.Services.AddScoped<IQuestionTypeRepo, QuestionTypeRepo>();
            builder.Services.AddScoped<IRoleRepo, RoleRepo>();
            builder.Services.AddScoped<IStudentCourseRepo, StudentCourseRepo>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
