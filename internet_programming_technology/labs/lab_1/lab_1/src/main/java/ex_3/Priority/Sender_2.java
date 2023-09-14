package ex_3.Priority;

import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;
import javax.jms.*;

public class Sender_2 {
    public static void main(String[] args){
        ConnectionFactory factory = new com.sun.messaging.ConnectionFactory();

        try (JMSContext context = factory.createContext("admin", "admin")){
            factory.setProperty(ConnectionConfiguration.imqAddressList, "mq://127.0.0.1:7676,mq://127.0.0.1:7676");
            Destination dest = context.createTopic("Ex3_2");

            while (true)
            {
                System.out.println("message has been send...");
                context.createProducer().setPriority(0).send(dest, "priority 0");
                Thread.sleep(1000);
            }
        } catch (InterruptedException | JMSException e) {
            throw new RuntimeException(e);
        }

    }
}
