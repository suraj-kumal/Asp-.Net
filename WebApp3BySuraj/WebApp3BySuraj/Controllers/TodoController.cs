using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp3BySuraj.Data;
using WebApp3BySuraj.Models;

namespace WebApp3BySuraj.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public IActionResult Index()
        {
            var todos = _todoRepository.GetAllTodos();
            return View(todos);
        }

        public IActionResult Details(int id)
        {
            var todo = _todoRepository.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _todoRepository.AddTodo(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public IActionResult Edit(int id)
        {
            var todo = _todoRepository.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _todoRepository.UpdateTodo(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public IActionResult Delete(int id)
        {
            var todo = _todoRepository.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _todoRepository.DeleteTodo(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
