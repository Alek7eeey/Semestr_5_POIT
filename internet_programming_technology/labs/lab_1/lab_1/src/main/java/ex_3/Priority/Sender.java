package ex_3.Priority;

import javax.jms.*;
import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;
public class Sender {
    public static void main(String[] args){
        ConnectionFactory factory = new com.sun.messaging.ConnectionFactory();

        try(JMSContext context = factory.createContext("admin", "admin")){
            factory.setProperty(ConnectionConfiguration.imqAddressList,  "mq://127.0.0.1:7676,mq://127.0.0.1:7676");
            Destination dest = context.createTopic("Ex3_2");

            while (true){
                System.out.println("Message has been sent");
                context.createProducer().setPriority(8).send(dest,"priority 8");
                Thread.sleep(1000);
            }

        } catch (JMSException | InterruptedException e) {
            throw new RuntimeException(e);
        }

    }
}
