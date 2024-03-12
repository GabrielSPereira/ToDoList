using System.Threading.Tasks;
using ToDoList.Entities;
using ToDoList.Models.InputModels;
using ToDoList.Persistence;
using ToDoList.Persistence.Migrations;

namespace ToDoList.Services
{
    public class UserService
    {
        private readonly ToDoListDbContext _context;
        private readonly AuthService _authService;

        public UserService(ToDoListDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public string Login(InputLogin inputLogin)
        {
            var passwordHash = _authService.ComputeSha256Hash(inputLogin.Password);
            var user = _context.Users.SingleOrDefault(u => u.Email == inputLogin.Email && u.Password == passwordHash);

            if (user is null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            var token = _authService.GenerateJwtToken(user.Email);

            return token;
        }

        public Entities.User CreateUser(InputUser createUser)
        {
            var passwordHash = _authService.ComputeSha256Hash(createUser.Password);
            var user = new Entities.User(createUser.Name, createUser.Email, passwordHash);
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
