using Microsoft.AspNetCore.Mvc;
using Web_App_MVC_L2.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Web_App_MVC_L2.Controllers
{
    public class TodoController : Controller
    {
        private const string SessionKey = "TodoList";

        public IActionResult Index()
        {
            var todoList = GetToDoList();
            return View(todoList);
        }

        [HttpPost]
        public IActionResult Add(string description)
        {
            var todoList = GetToDoList();

            var newItem = new TodoModel
            {
                Id = todoList.Count > 0 ? todoList.Max(x => x.Id) + 1 : 1,
                Description = description,
                IsCompleted = false
            };

            todoList.Add(newItem);
            SaveTodoList(todoList);

            return PartialView("_TodoList", todoList);
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            var todoList = GetToDoList();

            var item = todoList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.IsCompleted = true;
                SaveTodoList(todoList);
            }

            return PartialView("_TodoList", todoList);
        }

        [HttpPost]
        public IActionResult NotComplete(int id)
        {
            var todoList = GetToDoList();

            var item = todoList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.IsCompleted = false;
                SaveTodoList(todoList);
            }

            return PartialView("_TodoList", todoList);
        }

        public ActionResult Delete(int id)
        {
            var todoList = GetToDoList();

            var item = todoList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                todoList.Remove(item);
                SaveTodoList(todoList);
            }

            return PartialView("_TodoList", todoList);
        }


        private List<TodoModel> GetToDoList()
        {
            var sessionData = HttpContext.Session.GetString(SessionKey);
            if (string.IsNullOrEmpty(sessionData))
            {
                return new List<TodoModel>();
            }
            return JsonConvert.DeserializeObject<List<TodoModel>>(sessionData)!;
        }

        private void SaveTodoList(List<TodoModel> todoList)
        {
            HttpContext.Session.SetString(SessionKey, JsonConvert.SerializeObject(todoList));
        }
    }
}
