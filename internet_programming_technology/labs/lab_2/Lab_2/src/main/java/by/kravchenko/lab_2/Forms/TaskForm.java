package by.kravchenko.lab_2.Forms;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class TaskForm {
    private String nameOfTask;
    private String authorOfTask;
    private String commentsForTask;
}
