package by.kravchenko.lab_2.Model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;
@Data
@AllArgsConstructor
@NoArgsConstructor
public class Task {
    private String nameOfTask;
    private String authorOfTask;
    private String commentsForTask;
}
