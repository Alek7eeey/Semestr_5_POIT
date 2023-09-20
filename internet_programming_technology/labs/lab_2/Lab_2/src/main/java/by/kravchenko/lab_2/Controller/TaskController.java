package by.kravchenko.lab_2.Controller;

import by.kravchenko.lab_2.Forms.TaskForm;
import by.kravchenko.lab_2.Model.Task;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;

import java.util.ArrayList;
import java.util.List;

@Controller
public class TaskController {
    private static List<Task> tasks = new ArrayList<Task>();

    static {
        tasks.add(new Task("make new lab on Java", "Aleksey K.", "make new controller"));
        tasks.add(new Task("make new lab on ASP.net", "Aleksey K.", "make interface in welcome page"));
    }

    @Value("${welcome.message}")
    private String message;

    @Value("${error.message}")
    private String errorMessage;

    @GetMapping(value = {"/", "/index"})
    public ModelAndView Index(Model model){
        ModelAndView modelView = new ModelAndView();
        modelView.setViewName("index");
        model.addAttribute("tasks", tasks);
        message = "hello";
        return modelView;
    }

    @RequestMapping(value = {"/alltasks"}, method = RequestMethod.GET)
    public ModelAndView taskList(Model model) {
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setViewName("taskList");
        model.addAttribute("tasks", tasks);
        return modelAndView;
    }

    @GetMapping(value = {"/editTask"})
    public ModelAndView editTask(Model model) {
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setViewName("editTask");
        model.addAttribute("tasks", tasks);
        return modelAndView;
    }

    @GetMapping(value = {"deleteTask"})
    public ModelAndView showDeleteTaskPage(Model model){
        ModelAndView modelAndView = new ModelAndView("deleteTask");
        TaskForm taskForm = new TaskForm();
        model.addAttribute("taskForm", taskForm);

        return modelAndView;
    }

    @PostMapping(value = {"/deleteTask"})
    public ModelAndView deleteTask(Model model,
                                   @ModelAttribute("deleteTask")
                                   TaskForm taskForm){
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setViewName("taskList");
        String name = taskForm.getNameOfTask();
        boolean isFind = false;

        for (var a: tasks.stream().toList()
             ) {
            if(a.getNameOfTask().equals(name)){
                isFind = true;
                tasks.remove(a);
                break;
            }
        }

        if(isFind && name != null && name.length()>0){
            model.addAttribute("tasks",tasks);
            return modelAndView;
        }

        ModelAndView modelAndView2 = new ModelAndView("deleteTask");
        TaskForm taskForm2 = new TaskForm();
        model.addAttribute("taskForm", taskForm2);
        model.addAttribute("error","Not find this task and/or field is empty");

        return modelAndView2;
    }

    @GetMapping(value = {"/updateTask"})
    public  ModelAndView showUpdateTaskPage(Model model, @RequestParam String name,
                                         @RequestParam String author,
                                         @RequestParam String comments) {
        ModelAndView modelAndView = new ModelAndView("updateTask");
        TaskForm taskForm = new TaskForm();
        taskForm.setAuthorOfTask(author);
        taskForm.setNameOfTask(name);
        taskForm.setCommentsForTask(comments);
        model.addAttribute("taskForm", taskForm);
        model.addAttribute("nameOfTask", name);
        return modelAndView;
    }

    @PostMapping(value = {"/updateTask"})
    public ModelAndView updateTask(Model model, //
                                 @ModelAttribute("updateTask")
                                 TaskForm taskForm) {
        ModelAndView modelAndView = new ModelAndView();

        String title = taskForm.getNameOfTask();
        String author = taskForm.getAuthorOfTask();
        String comments = taskForm.getCommentsForTask();

        for (var a: tasks.stream().toList()
             ) {
            if(a.getNameOfTask().equals(title)){

                a.setAuthorOfTask(author);
                a.setCommentsForTask(comments);
                break;
            }
        }
            modelAndView.setViewName("taskList");
            model.addAttribute("tasks",tasks);
            return modelAndView;

    }

    @GetMapping(value = {"/addtask"})
    public  ModelAndView showAddTaskPage(Model model) {
        ModelAndView modelAndView = new ModelAndView("addtask");
        TaskForm taskForm = new TaskForm();
        model.addAttribute("taskForm", taskForm);
        return modelAndView;
    }

    @PostMapping(value = {"/addtask"})
    public ModelAndView saveTask(Model model, //
                                   @ModelAttribute("addtask")
                                   TaskForm taskForm) {
        ModelAndView modelAndView = new ModelAndView();

        String title = taskForm.getNameOfTask();
        String author = taskForm.getAuthorOfTask();
        String comments = taskForm.getCommentsForTask();

        if (    title != null && title.length() > 0 &&
                author != null && author.length() > 0 &&
                comments != null && comments.length() > 0) {

            modelAndView.setViewName("taskList");
            Task task = new Task(title, author, comments);
            tasks.add(task);
            model.addAttribute("tasks",tasks);
            return modelAndView;
        }

        ModelAndView modelAndView2 = new ModelAndView("addtask");
        TaskForm taskForm2 = new TaskForm();
        model.addAttribute("taskForm", taskForm2);
        model.addAttribute("error", errorMessage);

        return modelAndView2;
    }
}
