package ex_2.async;

import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;
import ex_2.FootballTeam;

import javax.jms.*;

public class DirectMessageSender {
    public static void main(String[] args){
        ConnectionFactory factory = new com.sun.messaging.ConnectionFactory();

        try(JMSContext context = factory.createContext("admin", "admin")){
            factory.setProperty(ConnectionConfiguration.imqAddressList,
                    "mq://127.0.0.1:7676,mq://127.0.0.1:7676");
            Destination messagesQueue = context.createQueue("Ex_2");

            FootballTeam footballTeam = new FootballTeam("ManchesterCity", "England", 35);

            ObjectMessage objMsg = context.createObjectMessage(footballTeam);

            JMSProducer producer = context.createProducer();
            producer.send(messagesQueue, objMsg);
            System.out.println("message has been sent");

        } catch (JMSException e) {
            System.out.println("ConnectionError: " + e.getMessage());
        }
    }
}
